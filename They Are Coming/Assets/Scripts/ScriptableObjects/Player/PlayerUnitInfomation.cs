using UnityEngine;

[CreateAssetMenu(fileName = "New Player Minion", menuName = "Scriptable Objects/Player Unit")]
public class PlayerUnitInfomation : ScriptableObject
{
    [Header("Name")]
    public new string name;

    [Header("Stats")]
    public int health;
    public float moveSpeed;
    public float sideSpeed;

    [Header("Model")]
    public GameObject model;
    public GameObject weaponHolder;
}
