using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUGBullet : Bullet
{
    private GameObject firstBullet;
    private GameObject secondBullet;
    private GameObject thirdBullet;

    private Vector3 direction1;
    private Vector3 direction2;


    public override void InitializeBullet(Vector3 position, Transform bulletStorage)
    {
        Quaternion rotation1 = Quaternion.Euler(direction1);
        Quaternion rotation2 = Quaternion.Euler(direction2);
        firstBullet = Instantiate(this.gameObject, position, rotation1, bulletStorage);
        secondBullet = Instantiate(this.gameObject, position, Quaternion.identity, bulletStorage);
        thirdBullet = Instantiate(this.gameObject, position, rotation2, bulletStorage);
    }

    public override void InitializeVariables()
    {
        direction1 = new Vector3(0, -15, 0);
        direction2 = new Vector3(0, 15, 0);
    }

    private void OnEnable()
    {
        InitializeVariables();
        InstantiateModel();
    }

    private void Update()
    {
        DestroyBullet();
    }
}
