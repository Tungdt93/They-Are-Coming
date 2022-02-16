﻿using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    public static PlayerMain playerMain;

    public GameObject visual;
    public Transform weaponHolder;
    public Transform spawnPoint;
    public Rigidbody rb;
    public CharacterController controller;
    public PlayerUnitInfomation unitInfo;

    public Vector3 centralizeVector;
    public float centralizeSpeed;
    public bool turnOffRb;
    public bool touched;

    public void InitializeVariables()
    {
        playerMain = PlayerMain.Instance;
        if (playerMain.Weapon != null)
        {
            InitializeWeapon();
        }
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        spawnPoint = playerMain.SpawnPosition.transform;
        centralizeSpeed = 100f;
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