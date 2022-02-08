using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject visual;
    public GameObject bulletType;
    public BoxCollider boxCollider;
    public WeaponInfomation weaponInfo;

    public float nextFire;
    public bool pickedUp;

    public void InitializeModel()
    {
        Instantiate(weaponInfo.model, transform);
    }

    public void InitializeVariables() 
    {
        boxCollider = GetComponent<BoxCollider>();
        pickedUp = false;
        visual = gameObject.transform.GetChild(0).gameObject;
    }
    
    public void Fire()
    {
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + weaponInfo.fireRate;
            InitializeProjectile();
        }
    }

    public void DisableVisual()
    {
        visual.SetActive(false);
    }

    public void InitializeProjectile() 
    {
        GameObject newBullet = Instantiate(bulletType, transform.position, Quaternion.identity, GameManager.Instance.BulletStorgage.transform);
        Bullet bullet = newBullet.GetComponent<Bullet>();
        bullet.gunDamage = weaponInfo.damage;    
    }

    public void PickedUpNewWeapon()
    {
        pickedUp = true;
        boxCollider.enabled = false;
    }

    public void DisableWeapon()
    {
        this.gameObject.SetActive(false);
    }
}