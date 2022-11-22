using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    public enum HookMovements{Normal, Swing}

    public HookMovements movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            other.GetComponent<Controller>().hookSwingPoint.Add(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            other.GetComponent<Controller>().hookSwingPoint.Remove(transform);
        }
    }
}
