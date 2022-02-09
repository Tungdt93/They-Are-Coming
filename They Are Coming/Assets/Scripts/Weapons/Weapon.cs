using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Bullet bulletType;
    public BoxCollider boxCollider;
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
        Instantiate(weaponInfo.model, transform);
    }

    public void InitializeVariables() 
    {
        boxCollider = GetComponent<BoxCollider>();
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
        bulletType.InitializeBullet(transform.position, GameManager.Instance.BulletStorgage.transform);
    }

    public void PickedUpNewWeapon()
    {
        this.pickedUp = true;
        this.boxCollider.enabled = false;
    }
}