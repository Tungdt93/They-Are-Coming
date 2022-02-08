using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponInfomation weaponInfo;
    public GameObject bulletType;
    public float nextFire;
    public bool pickedUp;

    public void InitializeModel()
    {
        weaponInfo.barrel = weaponInfo.model.transform.GetChild(0).gameObject;
        Instantiate(weaponInfo.model, transform);
    }

    public void InitializeVariables() 
    {
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
        GameObject newBullet = Instantiate(bulletType, transform.position, Quaternion.identity, GameManager.Instance.BulletStorgage.transform);   
        newBullet.GetComponent<Bullet>().gunDamage = weaponInfo.damage;    
    }
}