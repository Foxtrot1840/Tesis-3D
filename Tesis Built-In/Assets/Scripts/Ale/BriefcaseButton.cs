using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefcaseButton : MonoBehaviour
{
    private Text txt;
    private int _value;
    public BriefcaseCode code;
    public int rightNumber;
    
    private void Start()
    {
        txt = GetComponentInChildren<Text>();
        txt.text = "0";
    }

    public void ChangeNumber()
    {
        _value++;
        if (_value > 9) _value = 0;
        txt.text = _value.ToString();
        code.Check(_value == rightNumber ? true : false);
    }
}
