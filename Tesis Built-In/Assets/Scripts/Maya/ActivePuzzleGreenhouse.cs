using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePuzzleGreenhouse : Interactuables
{
    [SerializeField] private GameObject canvas, awuita;

    protected override void Action()
    {
        canvas.SetActive(true);
        GameManager.instance.PauseGame(true);
        GetComponent<Animator>().SetBool("Active",true);
        Destroy(this);
    }

    public void Desactive()
    {
        awuita.SetActive(true);
        Destroy(canvas);
        Destroy(this);
    }
}
