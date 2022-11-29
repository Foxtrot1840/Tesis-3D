using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExit : MonoBehaviour
{
    private int cartsExit;
    [SerializeField] private Animator _anim;

    public void CartCollide()
    {
        cartsExit++;
        if (cartsExit == 1)
        {
            _anim.SetBool("Break", true);
        }
        if(cartsExit >= 2)
        {
            _anim.SetBool("Break", false);
            _anim.SetBool("Destroy", true);
        }
    }

}
