using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineCart : Interactuables
{
    private bool active;
    private Action movement = delegate { };
    private Vector3 playerInitialPos, cartInitialPos;
    private float offset;
    private BoxCollider bColl;

    protected override void Start()
    {
        base.Start();
        bColl = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        movement();
    }

    protected override void Action()
    {
        active = !active;
        bColl.enabled = !active;
        playerInitialPos = active ? player.transform.position : Vector3.zero;
        cartInitialPos = active ? transform.position : Vector3.zero;
        movement = active ? (Action)FollowPlayer : delegate { };
    }

    private void FollowPlayer()
    {
        offset = playerInitialPos.x - player.transform.position.x;
        transform.position = cartInitialPos - Vector3.right * offset;
    }
}
