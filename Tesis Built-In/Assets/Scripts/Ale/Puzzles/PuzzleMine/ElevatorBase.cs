using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ElevatorBase : RotateBase
{
   [SerializeField] private float floor1, floor2, speedElevator;
   public bool rotation, elevation, isFloorOne;
   private float l;
   
   public bool ChangeFloor()
   {
      if (rotation || elevation) return false;
        if (Vector3.Distance(MineCart.position, transform.position) < range)
        {
            MineCart.parent = transform;
        }
        StartCoroutine(Translate(isFloorOne ? floor1 : floor2, isFloorOne ? floor2 : floor1));
      elevation = true;
      return true;
   }

   protected override void Update()
   {
      if (Input.GetKeyDown(KeyCode.Y)) ChangeFloor();
      ChangeState(Input.GetKey(KeyCode.G));
      base.Update();
   }

   public override void ChangeState(bool active)
   {
      if (elevation || isFloorOne) return;
      base.ChangeState(active);
      rotation = active;
   }

   IEnumerator Translate(float origin, float destiny)
   {
      GameManager.instance.player.transform.parent = transform;

      l = 0;
      float startRotation = transform.localRotation.eulerAngles.y;
      while (l<=1)
      {
         l += Time.deltaTime * speedElevator;
         transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(origin, destiny, l),
            transform.localPosition.z);
         transform.localRotation = Quaternion.Euler(Vector3.up *
                                                    Mathf.Lerp(startRotation,
                                                       isFloorOne ? startRotation + 90 : startRotation - 90, l));
         yield return new WaitForEndOfFrame();
      }

      isFloorOne = !isFloorOne;
      posA = transform.localRotation.eulerAngles.y;
      posB = posA + steps; 
      elevation = false;
      GameManager.instance.player.transform.parent = null;
   }
   
}
