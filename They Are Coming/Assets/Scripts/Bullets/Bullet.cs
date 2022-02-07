using UnityEngine;

public abstract class Bullet : MonoBehaviour, IProjectile
{
    public BulletInformation bulletInfo;
    public Rigidbody rb;
    public Vector3 direction;

    public void OnAddingForce()
    {
        
    }
}
