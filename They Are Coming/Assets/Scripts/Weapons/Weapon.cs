using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action OnPickedUp = delegate { };

    public BoxCollider boxCollider;
    public Bullet bulletType;
    public BulletSpawner bulletSpawner;
    public WeaponInfomation weaponInfo;
    public float nextFire;
    public bool initializedModel;
    public bool gameStarted;
    public bool stopFiring;
    public bool pickedUp;

    public void InitializeModel()
    {
        if (initializedModel)
        {
            return;
        }
        Instantiate(weaponInfo.gunModel, transform);
    }

    public void InitializeVariables()
    {
        boxCollider = GetComponent<BoxCollider>();
        bulletSpawner = GetComponent<BulletSpawner>();
        gameStarted = false;
        stopFiring = false;
    }

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + weaponInfo.fireRate;
            InitializeProjectile();
        }
    }

    public void InitializeProjectile()
    {
        bulletSpawner.InitializeBullet(transform.position);
    }

    public void PickedUpNewWeapon()
    {
        pickedUp = true;
        boxCollider.enabled = false;
        OnPickedUp?.Invoke();
    }

    public void CheckGameState()
    {
        gameStarted = GameManager.Instance.GameStarted;
        stopFiring = GameManager.Instance.StopFiring;
    }

    public void AllowToShoot()
    {
        if (stopFiring)
        {
            return;
        }

        if (gameStarted)
        {
            if (pickedUp)
            {
                Fire();
            }
        }

    }
}