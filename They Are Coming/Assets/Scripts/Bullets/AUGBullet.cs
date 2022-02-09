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

    private void Update()
    {
        DestroyBullet();
    }
}
