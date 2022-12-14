using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Model
{
    private Rigidbody _rb;
    private Transform _player;
    private float _speedRotation;
    private float _speedAim;
    private float _jumpForce;
    private Transform _hand;
    private Transform _hook;
    private Controller _controller;
    private LineRenderer _line;
    private float _currentSpeed;

    public bool isHooking;
    private bool _going;
    public Transform hookPoint;
    private HookPoint lastHookPoint;
    private Vector3 _hookOffset;
    private quaternion _hookRotation;

    private Vector3 _finalPos, _startPos;
    private float lerp;

    public Model(Controller controller, Rigidbody rb, Transform player, float speedRotation,
        float speedAim, float jumpForce, Transform hand,
        Transform hook, LineRenderer line)
    {
        _controller = controller;
        _rb = rb;
        _player = player;
        _speedRotation = speedRotation;
        _speedAim = speedAim;
        _jumpForce = jumpForce;
        _hand = hand;
        _hook = hook;
        _line = line;
        _hookOffset = _hook.transform.localPosition;
        _hookRotation = _hook.localRotation;
    }

    public void Move()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if(Physics.Raycast( _player.transform.position  + _player.up * 0.5f, _player.transform.forward,0.5f, _controller.stopWalking)) dir.z = Mathf.Clamp(dir.z, -1,0);
        _rb.MovePosition(_player.transform.position + Vector3.Normalize(_player.transform.right * dir.x + _player.transform.forward * dir.z) * _currentSpeed * Time.fixedDeltaTime);
        _controller._view.UpdateMove(dir);
    }

    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }
    
    //Rotacion del personaje en el eje Y
    public void Rotate()
    {
        _rb.MoveRotation(Quaternion.Euler(0,Camera.main.transform.rotation.eulerAngles.y,0));
        //_rb.MoveRotation(_rb.rotation * Quaternion.Euler(Vector3.up * Input.GetAxis("Mouse X") * _speedRotation * Time.deltaTime));
    }

    public void Jump()
    {
        _rb.AddForce(_player.transform.up * _jumpForce);
    }
    
    public bool IsGrounded()
    {
        return Physics.Raycast(_player.position + _player.up * 0.5f, _player.up * -1, 0.6f);
    }

    //Mueve el Gancho y cuando llega mueve al Player
    public void MoveHook()
    {
        _hook.position = Vector3.Lerp(_hook.position, lastHookPoint.transform.position, 5 * Time.fixedDeltaTime);
        if (Vector3.Distance(_hook.position, lastHookPoint.transform.position) < 0.5f)
        {
            StartAction();
            _controller.onFixedUpdate -= MoveHook;
        }
        _line.SetPosition(0, _hand.position);
        _line.SetPosition(1, _hook.position);
    }
    
    public void Grapping()
    {
        _player.position = Vector3.Lerp(_player.position, lastHookPoint.transform.position - _hand.localPosition, 5 * Time.fixedDeltaTime);
            if (Vector3.Distance(_player.position, lastHookPoint.transform.position - _hand.localPosition) < 0.7f)
            {
                _controller.onFixedUpdate = delegate { };
            } 
        _line.SetPosition(0, _hand.position);
        _line.SetPosition(1, _hook.position);
    }

    public void SwingHook()
    {
        Vector3 position = Vector3.Lerp(_startPos, _finalPos, lerp);
        position.y -= Mathf.Sin(lerp * Mathf.PI) * 2;

        _player.position = position;
        
        float vel = Mathf.Lerp(0.5f, 0, Mathf.Abs(lerp - 0.5f));//en los extremos se hace mas lento
        lerp += Time.deltaTime * vel * (_going ? 1 : -1);//0.35f
        if (lerp > 1 || lerp < 0)
        {
            lerp = Mathf.Clamp(lerp, 0, 1);
            _going = !_going;
        }
        
        //Debug.DrawLine(_startPos, _finalPos, Color.green);
        //Debug.DrawLine(position, hookPoint.transform.position, Color.red);
        
        _line.SetPosition(0, _hand.position);
        _line.SetPosition(1, _hook.position);
    }

    public void FailHook()
    {
        _hook.position = Vector3.Lerp(_hook.position, _hand.position, 5 * Time.fixedDeltaTime);
        if (Vector3.Distance(_hook.position, hookPoint.position) < 0.5f)
        {
           StopHooking();
        }
        _line.SetPosition(0, _hand.position);
        _line.SetPosition(1, _hook.position);
    }

    public void StartHooking()
    {
        Debug.Log("Start");
        lastHookPoint = hookPoint.GetComponent<HookPoint>();
        _hook.parent = null;
        _hook.LookAt(hookPoint.position);
        _line.enabled = true;
        //Si es Swing
        lerp = 0;
        _going = true;
        _startPos = _player.position;
        _startPos.y += 2;
        _finalPos = hookPoint.position - _player.position;
        _finalPos *= 2;
        _finalPos += _player.position;
        _finalPos.y = _startPos.y;
    }

    private void StartAction()
    {
        _rb.velocity = Vector3.zero;
        _rb.useGravity = false;
        _controller._view.ActiveAnimator(false);
        // Si se columpia:
        switch (hookPoint.GetComponent<HookPoint>().movement)
        {
            case HookPoint.HookMovements.Normal:
                _controller.onFixedUpdate += Grapping;
                break;
            case HookPoint.HookMovements.Swing:

                Debug.DrawLine(_startPos, _finalPos, Color.blue, 10f);
                
                _controller.onFixedUpdate += SwingHook;
                break;
            default:
                Debug.Log("Error en HookPoint no tiene asignado el movimiento");
                throw new ArgumentOutOfRangeException();
        }
        
    }
    
    //Activa los movimietos del Player despues del Hook
    public void StopHooking()
    {
        Debug.Log("Finish");
        _controller.onFixedUpdate = Move;
        _hook.parent = _hand;
        _hook.transform.localPosition = _hookOffset;
        _hook.transform.localRotation = _hookRotation;
        isHooking = false;
        _rb.useGravity = true;
        _line.enabled = false;
        _controller._view.ActiveAnimator(true);
        
        //Fuerza Adicional despues de columpiarse:
        if (lastHookPoint.movement == HookPoint.HookMovements.Swing)
        {
            //Debug.DrawLine(hookPoint.transform.position, _player.position, Color.green, 5);
            Vector3 dir = lastHookPoint.transform.position - _player.position;
            Vector2 offset = new Vector2(lastHookPoint.transform.position.x - _player.position.x, lastHookPoint.transform.position.z - _player.position.z);
            
            var a  = Quaternion.AngleAxis(180, Vector3.up) * dir;
            dir = Quaternion.AngleAxis(90, Vector3.Cross(dir, a)) * dir;
            
            //Debug.Log(_going + " " + lerp);
            if ((_going && lerp < 0.5f) || (!_going && lerp > 0.5f)) dir = Vector3.zero;
            //Debug.Log(dir);
            
            _rb.AddForce(dir.normalized * offset.magnitude * 0.5f, ForceMode.Impulse);
            //Debug.DrawLine(_player.position, _player.position + dir.normalized * offset.magnitude * 0.5f, Color.red, 5); //Aumentar el 0.5 para darle mas fuerza
        }

        lastHookPoint = null;
    }
}
