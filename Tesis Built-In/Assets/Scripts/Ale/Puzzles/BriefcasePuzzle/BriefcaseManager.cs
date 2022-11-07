using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefcaseManager : Interactuables
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject hookCollectable;

    private int _rightButtons;
    
    protected override void Action()
    {
        canvas.SetActive(true);
        GameManager.instance.PauseGame(true);
    }

    public void ClosePuzzle()
    {
        canvas.SetActive(false);
        GameManager.instance.PauseGame(false);
    }

    public void Check(bool right)
    {
        _rightButtons += right ? 1 : -1;
        if(_rightButtons >= 3) PuzzleComplete();
    }

    public void  PuzzleComplete()
    {
        hookCollectable.SetActive(true);
        ClosePuzzle();
        Destroy(gameObject);
    }
}
