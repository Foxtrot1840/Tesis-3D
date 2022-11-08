using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private string scene;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameManager.instance.player)
        {
            Debug.Log("Cambio");
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
