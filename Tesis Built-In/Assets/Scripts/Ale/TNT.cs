using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class TNT : MonoBehaviour, IDamagable
{
    public GameObject[] destroyObjects;
    public GameObject particles;
    
    public void GetDamage(int damage)
    {
        Explotion();
    }

    public void GetDamage(int damage, Vector3 point, Vector3 normal)
    {
        Explotion();
    }

    private void Explotion()
    {
        SoundManager.instance.Play(SoundID.TNT);
        Destroy(Instantiate(particles,transform.position + transform. up * 1f, quaternion.identity),3);
        foreach (var obj in destroyObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}