using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/Weapon")]
public class WeaponInfomation : ScriptableObject
{
    [Header ("Gun Name")]
    public new string name;

    [Header("Gun Stats")]
    public GameObject spawnPoint;
    public int damage;
    public int fireRate;

    [Header("Gun Model")]
    public GameObject model;
    public GameObject barrel;
}
