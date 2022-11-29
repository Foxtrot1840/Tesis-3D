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
    public Transform parent;
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
            //SoundManager.instance.Play(SoundID.MineCart);
            transform.parent = parent;
            _anim.enabled = true;
            _anim.SetBool("1", true);
        }
        if (id == 2 && (transform.localPosition.x >= 4 || transform.localPosition.x <= -4))
        {
            //SoundManager.instance.Play(SoundID.MineCart);
            transform.parent = parent;
            _anim.enabled = true;
            _anim.SetBool("2", true);
        }
    }

    public void PlaySound()
    {
        //SoundManager.instance.Stop(SoundID.MineCart);
        SoundManager.instance.Play(SoundID.MineCartCollision);
    }
    
    public void FinishAnimation()
    {
        exit.CartCollide();
    }

    public void DestroyMineCart() 
    {
        Destroy(gameObject);
    }
}
