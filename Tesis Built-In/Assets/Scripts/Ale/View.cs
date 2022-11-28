using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    private Animator _anim;

    public View(Animator animator)
    {
        _anim = animator;
    }

    public void UpdateMove(Vector3 dir)
    {
        _anim.SetBool("isWalking", dir.magnitude > 0);
    }

    public void Jump()
    {
        _anim.SetBool("canJump",true);
    }

    public void ResetJump()
    {
        _anim.SetBool("canJump", false);
    }

    public void Attack()
    {
        _anim.SetBool("isShooting", true);
    }

    public void Zoom(bool zoom)
    {
        _anim.SetBool("isZoom", zoom);
    }
    
    public void Sprint(bool sprint)
    {
        _anim.SetBool("isRunning",sprint);
    }
    
    public void Hit()
    {
        _anim.SetTrigger("GetDamage");
    }

 
    public void ActiveAnimator(bool active)
    {
        _anim.enabled = active;
    }
}