using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePuzzleGreenhouse : Interactuables
{
    protected override void Action()
    {
        CanvasManager.instance.ActivePuzzle(true);
        GetComponent<Animator>().SetBool("Active",true);
        Destroy(this);
    }
}
