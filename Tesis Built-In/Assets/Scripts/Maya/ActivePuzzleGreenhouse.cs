using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePuzzleGreenhouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            CanvasManager.instance.ActivePuzzle(true);
            Destroy(gameObject);
        }
    }
}
