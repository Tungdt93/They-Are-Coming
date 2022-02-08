using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Type", menuName = "Scriptable Objects/Bullet")]
public class BulletInformation : ScriptableObject
{
    [Header("Name")]
    public new string name;

    [Header("Stats")]
    public float moveSpeed;

    [Header("Model")]
    public GameObject model;
}
