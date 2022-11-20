using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    Action movement = delegate {};
    public float lerp, posA, posB;
    [SerializeField] private int steps;
    [SerializeField] private float speed;
    [SerializeField] private Transform MineCart;
    [SerializeField] private float range;

    private void Start()
    {
        posA = transform.localRotation.z;
        posB = posA + steps;
    }

    private void Update()
    {
        movement();
    }

    public void ChangeState(bool active)
    {
        if (active)
        {
            movement = Rotate;
        }
        else
        {
            movement = delegate {};
            transform.localRotation = Quaternion.Euler(0, lerp < 0.5f ? posA : posB, 0);
            //Comprobar si el carrito esta dentro:
            if (Vector3.Distance(MineCart.position, transform.position) < range)
            {
                MineCart.parent = transform;
            }
        }
    }

    private void Rotate()
    {
        lerp += Time.deltaTime * speed / 100;
        float rotation = Mathf.Lerp(posA, posB, lerp);
        if (lerp >= 1)
        {
            posA += steps;
            posB += steps;
            lerp = 0;
        }

        transform.localRotation = Quaternion.Euler(0, rotation, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
