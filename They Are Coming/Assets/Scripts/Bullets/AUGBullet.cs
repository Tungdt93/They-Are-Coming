using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUGBullet : Bullet
{
    private void OnEnable()
    {
        InitializeVariables();
        InstantiateModel();
        OnAddingForce();
    }

    private void InitializeVariables()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.forward;
    }

    private void Update()
    {
        DestroyBullet();
    }
}
