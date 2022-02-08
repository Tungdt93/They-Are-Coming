using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponInfomation weaponInfo;
    public GameObject bulletType;

    public void InstantiateModel()
    {
        weaponInfo.barrel = weaponInfo.model.transform.GetChild(0).gameObject;
        GameObject weapon = Instantiate(weaponInfo.model, transform);
    }

    public void Fire()
    {
        InvokeRepeating("InstaniateProjectile", 0f, weaponInfo.fireRate);
    }

    public void InstaniateProjectile() 
    {
        GameObject newBullet = Instantiate(bulletType, weaponInfo.barrel.transform.position, Quaternion.identity, this.transform);
    }
}