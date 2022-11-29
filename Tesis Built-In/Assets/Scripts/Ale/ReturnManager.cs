using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnManager : MonoBehaviour
{
    [SerializeField] private GameObject briefcase, gun, gearGraveyard;
    [SerializeField] private PuzzleManager graveyardDoor;
    [SerializeField] private Porton porton;
    [SerializeField] private GameObject destruccion, TNT, mineEnter;
    [SerializeField] private ActivePuzzleGreenhouse _greenhouse;

    void Start()
    {
        if(PlayerPrefs.GetInt(Tools.hook.ToString()) == 1) Destroy(briefcase);
        if(PlayerPrefs.GetInt(Tools.gun.ToString()) == 1) Destroy(gun);
        if(PlayerPrefs.GetInt(Gears.Graveyard.ToString())==1)Destroy(gearGraveyard);
        
        if(PlayerPrefs.GetInt(Gears.Graveyard.ToString())==1)porton.GetDamage(1);
        if (PlayerPrefs.GetInt(Gears.Train.ToString()) == 1)
        {
            Destroy(mineEnter);
            Destroy(destruccion);
            Destroy(TNT);
        }

        if (PlayerPrefs.GetInt(Gears.Graveyard.ToString()) == 1) graveyardDoor.OpenDoor();
        if (PlayerPrefs.GetInt(Gears.Greenhouse.ToString()) == 1) _greenhouse.Desactive();
    }


}
