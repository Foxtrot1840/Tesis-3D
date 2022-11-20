using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CrystalGear : Entity
{
    [SerializeField] private int life;
    [SerializeField] private GearCollectable gear;
    
    void Start()
    {
        currentHealth = life;
    }

    public override void GetDamage(int damage)
    {
        transform.position -= Vector3.zero - Vector3.down * 0.4f;
        base.GetDamage(damage);
    }

    public override void GetDamage(int damage, Vector3 point, Vector3 normal)
    {
        transform.position -= Vector3.zero - Vector3.down * 0.4f;
        base.GetDamage(damage, point, normal);
    }

    public override void Die()
    {
        gear.enabled = true;
        base.Die();
    }
}
