using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject _player;
    private Controller _plyController;

    public GameObject player
    {
        get { return _player; }
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        Time.timeScale = 1;
        _plyController = player.GetComponent<Controller>();
        
        _plyController.hook = PlayerPrefs.GetInt(Tools.hook.ToString()) == 1;
        _plyController.hookObj.SetActive(PlayerPrefs.GetInt(Tools.hook.ToString()) == 1);
        _plyController.gun = PlayerPrefs.GetInt(Tools.gun.ToString()) == 1;
        _plyController.gunObj.SetActive(PlayerPrefs.GetInt(Tools.gun.ToString()) == 1);

        _plyController.lastSavePoint =
            new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Map" && _plyController.lastSavePoint != Vector3.zero)
        {
            player.transform.position = _plyController.lastSavePoint;
        }
        
        if(PlayerPrefs.GetInt(Gears.Graveyard.ToString())==1) _plyController.gearInventary.Add(Gears.Graveyard);
        if(PlayerPrefs.GetInt(Gears.Greenhouse.ToString())==1) _plyController.gearInventary.Add(Gears.Greenhouse);
        if(PlayerPrefs.GetInt(Gears.Train.ToString())==1) _plyController.gearInventary.Add(Gears.Train);
        
        EventManager.Subscribe(EventManager.EventsType.Event_FinishGame,FinishLevel);
    }

    public void FinishLevel(params object[] p)
    {   
        EventManager.ClearEvents();
        Time.timeScale = 0;
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = pause;
    }
}
