using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotateBase : MonoBehaviour
{
    private Action movement = delegate {};
    protected float lerp, posA, posB;
    [SerializeField] protected int steps;
    [SerializeField] private float speed;
    [SerializeField] protected Transform MineCart;
    [SerializeField] protected float range;

    private void Start()
    {
        posA = transform.localRotation.z;
        posB = posA + steps;
    }

    protected virtual void Update()
    {
        movement();
    }

    public virtual void ChangeState(bool active)
    {
        if (active)
        {
            movement = Rotate;
            Debug.Log("A");
        }
        else
        {
            Debug.Log("B");
            movement = delegate {};
            transform.localRotation = Quaternion.Euler(0, lerp < 0.5f ? posA : posB, 0);
        }
            //Comprobar si el carrito esta dentro:
        if (Vector3.Distance(MineCart.position, transform.position) < range)
        {
            if (Vector3.Distance(MineCart.position, transform.position) + 1 > range)
            {
                //Carrito adentro pero no del todo
                MineCart.transform.position += Vector3.forward * 1f;
            }
            MineCart.parent = transform;
        }
        else if (Vector3.Distance(MineCart.position, transform.position) - 1 < range)
        {
            //Carrito cerca pero fuera del rango
            MineCart.transform.localPosition -= Vector3.forward * 1f;
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
