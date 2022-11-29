using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    [SerializeField] private RotateBase rotateBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            rotateBase.ChangeState(true);
            SoundManager.instance.Play(SoundID.RotatePlatform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            rotateBase.ChangeState(false);
            SoundManager.instance.Stop(SoundID.RotatePlatform);
        }
    }
}
