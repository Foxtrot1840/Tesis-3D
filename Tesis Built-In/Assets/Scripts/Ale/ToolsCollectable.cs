using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tools
{
    hook, gun
}

public class ToolsCollectable : Interactuables
{
    [SerializeField] private Tools type;
    
    protected override void Action()
    {
        if (type == Tools.gun)
        {
            plyController.gun = true;
            plyController.gunObj.SetActive(true);
        }
        else
        {
            plyController.hook = true;
            plyController.hookObj.SetActive(true);
        }
        Destroy(gameObject);
    }
}
