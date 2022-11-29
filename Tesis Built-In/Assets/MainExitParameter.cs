using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainExitParameter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            PlayerPrefs.SetFloat("x", 130.64f);
            PlayerPrefs.SetFloat("y", -0.61f);
            PlayerPrefs.SetFloat("z", 37.13f);
        }
    }
}
