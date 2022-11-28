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
            _anim.SetBool("Destroy", true);
            transform.position += Vector3.right * 5;
            GameManager.instance.player.GetComponent<Controller>().lastSavePoint = new Vector3(73.56f, -0.45f, -33.1f);
            PlayerPrefs.SetFloat("x", 130.64f);
            PlayerPrefs.SetFloat("y", -0.61f);
            PlayerPrefs.SetFloat("z", 37.13f);
        }
    }

}
