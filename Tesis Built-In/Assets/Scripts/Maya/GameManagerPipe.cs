using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPipe : MonoBehaviour
{
    public GameObject pipesHolder;
    public GameObject[] pipes;
    public GameObject gear, awuita;
    [SerializeField] GameObject canvas;

    [SerializeField]
    int totalPipes = 0;

    [SerializeField]
    int correctedPipes = 0;

    void Start()
    {
        totalPipes = pipesHolder.transform.childCount;

        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = pipesHolder.transform.GetChild(i).gameObject;
        }
    }

    IEnumerator TimeGear()
    {
        Debug.Log("GEAR");
        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(false);
        GameManager.instance.PauseGame(false);
        gear.SetActive(true);
        awuita.SetActive(true);
    }

    public void CorrectMove()
    {
        correctedPipes += 1;

        if (correctedPipes == totalPipes)
        {
            Time.timeScale = 1;
            StartCoroutine(TimeGear());
        }
    }

    public void WrongMove()
    {
        correctedPipes -= 1;
    }
}
