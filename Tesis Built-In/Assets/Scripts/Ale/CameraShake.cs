using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraShake : MonoBehaviour
{
   public void StartShake(float duration, float magnitude)
   {
      StartCoroutine(Shake(duration, magnitude));
   }

   public void ShakeItOff()
   {
      StartCoroutine(Shake(1.8f, .3f));
   }
   
   IEnumerator Shake(float dur, float mag)
   {
      Vector3 originalPos = transform.localPosition;

      float elapsed = 0f;

      while (elapsed < dur)
      {
         float x = Random.Range(-1f, 1f) * mag;
         float y = Random.Range(-1f, 1f) * mag;
         transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
         elapsed += Time.deltaTime;
         yield return null;
      }
      transform.localPosition = originalPos;
   }
}
