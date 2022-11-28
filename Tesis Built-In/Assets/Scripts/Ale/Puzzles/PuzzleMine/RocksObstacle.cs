using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] tnts = new GameObject[1];
    [SerializeField] private GameObject director;
    
    private void OnDisable()
    {
        foreach (var tnt in tnts)
        {
            if (tnt == null) continue;
            tnt.GetComponent<IDamagable>().GetDamage(1);
        }
        director.SetActive(true);
        Destroy(director,3.5f);
    }
}
