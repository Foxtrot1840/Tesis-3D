using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePuzzleGreenhouse : Interactuables
{
    [SerializeField] GameObject canvas;

    protected override void Action()
    {
        canvas.SetActive(true);
        GameManager.instance.PauseGame(true);
        GetComponent<Animator>().SetBool("Active",true);
    }
}
