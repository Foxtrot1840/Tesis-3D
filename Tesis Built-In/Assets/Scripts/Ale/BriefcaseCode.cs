using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefcaseCode : MonoBehaviour
{
    public int[] code = new int[3];
    public BriefcaseButton[] buttons = new BriefcaseButton[3];
    private int rightButtons;
    
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].rightNumber = code[i];
        }
    }

    public void Check(bool right)
    {
        rightButtons += right ? 1 : -1;
        if (rightButtons == 3)
        {
            Debug.Log("Complete");
        }
    }
    
}
