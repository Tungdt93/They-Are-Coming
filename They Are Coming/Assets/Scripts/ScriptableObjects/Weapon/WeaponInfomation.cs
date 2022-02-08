﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Weapon")]
public class WeaponInfomation : ScriptableObject
{
    [Header ("Gun Name")]
    public new string name;

    [Header("Gun Stats")]
    public GameObject barrel;
    public int damage;
    public float fireRate;

    [Header("Gun Model")]
    public GameObject model;
}
