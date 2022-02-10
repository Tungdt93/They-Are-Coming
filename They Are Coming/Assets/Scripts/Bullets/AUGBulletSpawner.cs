using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUGBulletSpawner : BulletSpawner
{
    [SerializeField] private Vector3 firstBulletDirection;
    [SerializeField] private Vector3 thirdBulletDirection;
    private Vector3 secondBulletDirection;

    private Quaternion firstBulletRotation;
    private Quaternion thirdBulletRotation;

    private void OnEnable() 
    {
       InitializeVariables();
    }

    public override void InitializeVariables()
    {
        secondBulletDirection = Vector3.forward;
        firstBulletRotation = Quaternion.Euler(firstBulletDirection);       
        thirdBulletRotation = Quaternion.Euler(thirdBulletDirection);
        weapon = GetComponent<Weapon>();
        bullet = weapon.bulletType;
    }

    public override void InitializeBullet(Vector3 position)
    {
        GameObject firstBullet = Instantiate(bullet.gameObject, position, firstBulletRotation, GameManager.Instance.BulletStorgage.transform);
        firstBullet.GetComponent<Bullet>().OnAddingForce(firstBulletDirection);
        GameObject secondBullet = Instantiate(bullet.gameObject, position, Quaternion.identity, GameManager.Instance.BulletStorgage.transform);
        secondBullet.GetComponent<Bullet>().OnAddingForce(secondBulletDirection);
        GameObject thirdBullet = Instantiate(bullet.gameObject, position, thirdBulletRotation, GameManager.Instance.BulletStorgage.transform);
        thirdBullet.GetComponent<Bullet>().OnAddingForce(thirdBulletDirection);
    }
}
