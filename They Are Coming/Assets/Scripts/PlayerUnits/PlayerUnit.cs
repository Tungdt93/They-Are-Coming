﻿using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    public static PlayerMain playerMain;

    public GameObject visual;
    public Transform weaponHolder;
    public Rigidbody rb;
    public PlayerUnitInfomation unitInfo;

    public Vector3 centralizedDirection;

    public void InitializeVariables()
    {
        playerMain = PlayerMain.Instance;
        if (playerMain.Weapon != null)
        {
            InitializeWeapon();
        }
        rb = GetComponent<Rigidbody>();
    }
    public void InitializeModel()
    {
        Instantiate(unitInfo.model, this.visual.transform);    
    }

    public void InitializeWeapon()
    {
        if (weaponHolder.childCount > 0) 
        {
            Destroy(weaponHolder.transform.GetChild(0).gameObject);
        }
        GameObject newWeapon = Instantiate(playerMain.Weapon.gameObject, weaponHolder.transform.position, Quaternion.identity, weaponHolder.transform);    
        Weapon weapon = newWeapon.GetComponent<Weapon>();
        weapon.PickedUpNewWeapon();
    }
}
