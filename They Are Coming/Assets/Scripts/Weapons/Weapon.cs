using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponInfomation weaponInfomation;
    public float elapsedTime = 0;

    public void InstantiateModel()
    {
        weaponInfomation.spawnPoint = weaponInfomation.model.transform.GetChild(0).gameObject;
        GameObject weapon = Instantiate(weaponInfomation.model, transform);
        weapon.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void Fire()
    {

    }
}