using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineCart : Interactuables
{
    private bool active;
    //private Action movement = delegate { };
    private Vector3 playerInitialPos, cartInitialPos;
    private float offset;
    private Animator _anim;
    [SerializeField] private float posX;
    [SerializeField] private GameObject wall;

    protected override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.x < posX)
        {
            _anim.enabled = true;
            _anim.SetTrigger("Movement");
        }
        //movement();
    }

    protected override void Action()
    {
        /*active = !active;
        bColl.enabled = !active;
        playerInitialPos = active ? player.transform.position : Vector3.zero;
        cartInitialPos = active ? transform.position : Vector3.zero;
        movement = active ? (Action)FollowPlayer : delegate { };*/
    }

    private void FollowPlayer()
    {
        offset = playerInitialPos.x - player.transform.position.x;
        transform.position = cartInitialPos - Vector3.right * offset;
    }

    public void DestroyWall()
    {
        Destroy(wall);
    }
    
}
