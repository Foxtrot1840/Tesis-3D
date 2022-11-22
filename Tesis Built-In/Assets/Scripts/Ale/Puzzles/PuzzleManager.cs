using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleCircle[] circles = new PuzzleCircle[5];
    public GameObject[] buttons;
    public Animator animatorDoor;
    
    private void Awake()
    {
        foreach (var circle in circles)
        {
            circle.manager = this;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))OpenDoor();
    }

    public void Check()
    {
        if (circles.All(x => x._activate == false))
        {
            float angle = circles[0].transform.localRotation.eulerAngles.z;
            var cont = 0;
            foreach (var circle in circles)
            {
                Debug.Log((int)circle.transform.localRotation.eulerAngles.z + "  " + angle);
                if (Mathf.Approximately(circle.transform.localRotation.eulerAngles.z, angle)) 
                {
                    Debug.Log("uno bien");
                    cont++;
                }
                else
                {
                    Debug.Log("uno mal");
                }
            }
            if (cont == circles.Length)
            {
                foreach (var circle in circles)
                {
                    circle._onUpdate += circle.RotateToFinal;
                }

                foreach (var button in buttons)
                {
                    button.SetActive(false);
                }

                Invoke(nameof(CompletePuzzle), 1);
            }
        }
    }

    public void CompletePuzzle()
    {
        animatorDoor.SetBool("Open", true);
    }

    public void OpenDoor()
    {
        foreach (var circle in circles)
        {
            circle._onUpdate = circle.RotateToFinal;
        }

        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
        animatorDoor.SetBool("Open", true);
    }
}
