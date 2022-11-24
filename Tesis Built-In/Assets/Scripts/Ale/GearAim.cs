using System;
using System.Collections;
using System.Collections.Generic;
using AmplifyShaderEditor;
using UnityEngine;

public class GearAim : MonoBehaviour
{
    private RectTransform transform;
    [SerializeField] private float speed;

    private void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    public void Rotate()
    {
        transform.rotation = Quaternion.Euler(0,0,speed + transform.rotation.eulerAngles.z);
    }
    

}
