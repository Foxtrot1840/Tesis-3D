using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Porton : MonoBehaviour, IDamagable
{
   private LineRenderer _line;
   private Animator _anim;
   [SerializeField] private Transform[] points = new Transform[2];

   private void Start()
   {
      _line = GetComponent<LineRenderer>();
      _anim = GetComponent<Animator>();
   }
   
   private void LateUpdate()
   {
       for (int i = 0; i < points.Length; i++)
       {
           _line.SetPosition(i, points[i].position);
       }
   }

   public void GetDamage(int damage)
   {       
       _anim.SetBool("Open", true);
   }

   public void GetDamage(int damage, Vector3 point, Vector3 normal)
   {
       _anim.SetBool("Open", true);
   }
}
