    using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cinemachine;
    using Unity.Mathematics;
    using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Controller : Entity
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _speedAimRotation;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _sprint = 10;
    [SerializeField] private float _speedRotation = 50;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private GameObject _shootParticles;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _layerShoot;
    [SerializeField] private Transform _hook;
    [SerializeField] private Transform _hand;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private float viewAngle;
    [SerializeField] public LayerMask stopWalking;
    [SerializeField] private ParticleSystem shootWall;
    [SerializeField] private CameraFollow tracker;
    public GameObject hookObj, gunObj;
    public bool hook, gun;
    public GearAim mira;
    

    private Rigidbody _rb;
    private Animator _anim;
    private Model _model;
    public View _view;

    private bool _isZoom;
    private float zoomLerp;

    public List<Enum> gearInventary = new List<Enum>();
    public Vector3 lastSavePoint;

    public Action onFixedUpdate = delegate{ };
    public event Action interactables;
    public List<Transform> hookSwingPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _model = new Model(this, _rb, transform, _speedRotation, _speedAimRotation, _jumpForce, _hand, _hook, _line);
        _view = new View(_anim);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        currentHealth = _maxHealth;
        onFixedUpdate += _model.Move;
        _model.SetSpeed(_speed);
    }

    private void Update()
    {
        _model.Rotate();

        _isZoom = Input.GetMouseButton(1);
        mira.gameObject.SetActive(_isZoom);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 30,
                _layerShoot))
        {
            IDamagable d = hit.collider.GetComponent<IDamagable>();
            if (d != null)
            {
                mira.Rotate();
            }
        }
        //TRACKER
        zoomLerp += _isZoom ? 2.5f * Time.deltaTime : -2.5f * Time.deltaTime;
        zoomLerp = Mathf.Clamp(zoomLerp, 0, 1);
        tracker.lerpZoom = zoomLerp;
        tracker.distance = Mathf.Lerp(3, 2, zoomLerp);

        //El click izquierdo se realiza la animacion de ataque
        ////(el animator pregunta si se apunta se hace un disparo, sino se usa la espada) 
        if (Input.GetMouseButtonDown(0) && gun && _isZoom)
        {
            _view.Attack();
        }
        
        if (Input.GetButtonDown("Jump") && _model.IsGrounded())
        {
            Sprint(false);
            _view.Jump();
            _model.Jump();
        }

        if (hook)
        {
            if (FieldOfView() != _model.hookPoint)
            {
                if (_model.hookPoint != null) _model.hookPoint.GetComponent<HookPoint>().ActiveFeedback(false);
                _model.hookPoint = FieldOfView();
                if (FieldOfView() != null) _model.hookPoint.GetComponent<HookPoint>().ActiveFeedback(true);
            }
        }
        
        CanvasManager.instance.ShowKeyE(interactables != null || _model.hookPoint!= null);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactables != null)
            {
                interactables.Invoke();
                return;
            }

            if (_model.hookPoint != null && !_model.isHooking)
            {
                _model.StartHooking();
                _line.enabled = true;
                onFixedUpdate = _model.MoveHook;
                _model.isHooking = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && _model.isHooking)
        {
            _model.StopHooking();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))Sprint(true);

        if (Input.GetKeyUp(KeyCode.LeftShift)) Sprint(false); 
    }

    private void FixedUpdate()
    {
        onFixedUpdate();
    }

    public void Shoot()
    {
        Destroy(Instantiate(_shootParticles, _shootPoint.position, _shootPoint.rotation), 2);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 30, _layerShoot))
        {
            SoundManager.instance.Play(SoundID.Disparo);
            IDamagable d = hit.collider.GetComponent<IDamagable>();
            if (d != null)
            {
                d.GetDamage(1, hit.point, hit.normal);
            }
            else
            {
                var a = Instantiate(shootWall, hit.point, Quaternion.Euler(hit.normal));
                a.transform.forward = (transform.position - hit.point).normalized;
            }
        }
    }

    public void Sprint(bool active)
    {
        if (active)
        {
            _model.SetSpeed(_sprint);
        }
        else
        {
            _model.SetSpeed(_speed);
        }
        _view.Sprint(active);
    }
    
    public void ResetJump()
    {
        _view.ResetJump();
    }

    public void ResetShoot()
    {
        _anim.SetBool("isShooting", false);
    }

    private Transform FieldOfView()
    {
        foreach (var point in hookSwingPoint)
        {
            Vector3 dir = point.position - transform.position;
            if (Vector3.Angle(Camera.main.transform.forward, dir) <= viewAngle / 2)
            {
                return point;
            }
        }
        return null;
    }

    public void GetLife(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, _maxHealth);
        EventManager.TriggerEvent(EventManager.EventsType.Event_GetDamage, currentHealth, _maxHealth);
    }
    
    public override void GetDamage(int damage)
    {
        currentHealth -= damage;
        _view.Hit();
        EventManager.TriggerEvent(EventManager.EventsType.Event_GetDamage, currentHealth, _maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        EventManager.TriggerEvent(EventManager.EventsType.Event_FinishGame, false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }
}
