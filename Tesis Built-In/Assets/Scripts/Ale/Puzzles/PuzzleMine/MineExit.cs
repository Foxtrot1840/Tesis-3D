using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExit : MonoBehaviour
{
    private int cartsExit;

    public void CartCollide()
    {
        cartsExit++;
        Debug.Log(cartsExit);
        if(cartsExit >= 2)
        {
            transform.position += Vector3.right * 5;
            GameManager.instance.player.GetComponent<Controller>().lastSavePoint = new Vector3(73.56f, -0.45f, -33.1f);
            PlayerPrefs.SetFloat("x", 130.64f);
            PlayerPrefs.SetFloat("y", -0.61f);
            PlayerPrefs.SetFloat("z", 37.13f);
        }
    }

}
