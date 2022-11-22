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
    [SerializeField] private MineExit exit;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        parent = transform.parent;
    }

    private void Update()
    {
        if (id == 1 && (transform.localPosition.x >= 4 || transform.localPosition.x <= -4))
        {
            transform.parent = parent;
            _anim.enabled = true;
            _anim.SetBool("1", true);
        }
        if (id == 2 && (transform.localPosition.x >= 4 || transform.localPosition.x <= -4))
        {
            transform.parent = parent;
            _anim.enabled = true;
            _anim.SetBool("2", true);
        }
    }

    public void FinishAnimation()
    {
        exit.CartCollide();
        Destroy(gameObject);
    }
}
