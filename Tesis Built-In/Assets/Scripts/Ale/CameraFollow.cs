using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class CameraFollow : MonoBehaviour
{
   public float distance, lerpZoom;
   [SerializeField] private float mouseSensitivity;
   [SerializeField] private float hitOffset;
   [SerializeField] private Transform target;
   [SerializeField] private Transform targetZoom;
   [SerializeField] private LayerMask cameraCollision;

    private float _mouseX, _mouseY;
   private Vector3 _camPos, _direction;

   private RaycastHit _raycastHit;
   private bool _isCameraBlocked;

   private void FixedUpdate()
   {
      _isCameraBlocked =
         Physics.SphereCast(transform.position, 0.1f, _direction, out _raycastHit, distance, cameraCollision);
   }

   private void Update()
   {
      transform.position = Vector3.Lerp(target.position, targetZoom.position, lerpZoom);

      _mouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
      _mouseY += Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

      if (_mouseX >= 360 || _mouseX <= -360)
      {
         _mouseX -= 360 * Mathf.Sign(_mouseX);
      }

      _mouseY = Mathf.Clamp(_mouseY, -30f, 30f);

      transform.rotation = Quaternion.Euler(-_mouseY, _mouseX, 0f);

      _direction = -transform.forward;

      if (_isCameraBlocked)
      {
         _camPos = _raycastHit.point - _direction * hitOffset;
      }
      else
      {
         _camPos = transform.position + _direction * distance;
      }

      Camera.main.transform.position = _camPos;
      
      Camera.main.transform.LookAt(transform.position);
   }
   
   void OnDrawGizmos()
   {
      var position = transform.position;

      Gizmos.color = Color.blue;

      Gizmos.DrawSphere(position, 0.1f);

      Gizmos.DrawSphere(_camPos, 0.1f);

      Gizmos.color = Color.red;

      Gizmos.DrawLine(position,_camPos);    
   }
   
}
