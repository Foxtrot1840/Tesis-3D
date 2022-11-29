using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollectable : Interactuables
{
    [SerializeField] private Gears type;
    
    protected override void Action()
    {
       plyController.gearInventary.Add(type);
       PlayerPrefs.SetInt(type.ToString(), 1);
       SoundManager.instance.Play(SoundID.GearCollected,false,0.3f);
       Destroy(gameObject);
    }
}
