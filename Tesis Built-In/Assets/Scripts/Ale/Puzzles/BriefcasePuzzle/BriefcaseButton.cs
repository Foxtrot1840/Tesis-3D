using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BriefcaseButton : MonoBehaviour
{
    private Text _text;
    public int rightNumber;
    private int _num;
    [SerializeField] private BriefcaseManager manager;
    private bool _right;
    
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _text.text = "0";
    }

    public void ChangeNumber()
    {
        _num++;
        if (_num > 9) _num = 0;
        _text.text = _num.ToString();
        if (_right)
        {
            if (_num != rightNumber)
            {
                manager.Check(false);
                _right = !_right;
            }
        }
        else
        {
            if (_num == rightNumber)
            {
                _right = !_right;
                manager.Check(true);
            }
        }
    }
}
