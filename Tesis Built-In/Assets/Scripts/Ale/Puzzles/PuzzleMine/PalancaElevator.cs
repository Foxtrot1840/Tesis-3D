using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaElevator : Interactuables
{
   [SerializeField] private ElevatorBase elevatorBase;
   private bool active = false;
   private Animator _anim;

   protected override void Start()
   {
      base.Start();
      _anim = GetComponent<Animator>();
   }

   protected override void Action()
   {
      if (elevatorBase.ChangeFloor())
      {
         active = !active;
         _anim.SetBool("Active", active);
      }
   }
}
