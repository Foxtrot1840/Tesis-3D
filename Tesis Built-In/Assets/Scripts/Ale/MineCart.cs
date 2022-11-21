using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MineCart : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody _rb;
    public int id;
    private Transform parent;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        parent = transform.parent;
    }

    private void Update()
    {
        if (id == 1 && transform.localPosition.x >= 4)
        {
            transform.parent = parent;
            _anim.enabled = true;
            _anim.SetBool("1", true);
        }
    }

    public void FinishAnimation()
    {
        Destroy(gameObject);
    }
}
