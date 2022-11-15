using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : Interactuables
{
    public List<PuzzleCircle> circles;
    private bool active;
    private Animator _anim;

    protected override void Start()
    {
        base.Start();
        _anim = GetComponent<Animator>();
        active = false;
    }

    protected override void Action()
    {
        active = !active;
        _anim.SetBool("Active", active);
        foreach (var circle  in circles)
        {
            circle.ChangeState();
        }
    }
}
