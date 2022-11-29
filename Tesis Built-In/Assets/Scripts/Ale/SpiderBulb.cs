using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpiderBulb : MonoBehaviour,IDamagable
{
    public void GetDamage(int damage)
    {
        transform.parent.GetComponent<Spider>().Die();
    }

    public void GetDamage(int damage, Vector3 point, Vector3 normal)
    {
        transform.parent.GetComponent<Spider>().Die();
    }
}
