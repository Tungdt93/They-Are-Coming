using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    public Weapon weapon;
    public Bullet bullet;
    
    public abstract void InitializeVariables();

    public abstract void InitializeBullet(Vector3 position);
}
