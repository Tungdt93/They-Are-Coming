using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Bullet bulletType;
    public BulletSpawner bulletSpawner;
    public WeaponInfomation weaponInfo;
    public float nextFire;
    public bool initializedModel;
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
        pickedUp = false;
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
        this.pickedUp = true;
        this.boxCollider.enabled = false;
    }
}