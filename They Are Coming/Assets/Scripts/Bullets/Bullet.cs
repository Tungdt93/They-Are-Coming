using UnityEngine;

public abstract class Bullet : MonoBehaviour, IProjectile
{
    public BulletInformation bulletInfo;
    public Rigidbody rb;
    public Vector3 direction;
    public float timeDelay;
    public int gunDamage;

    public void DestroyBullet() 
    {
        Destroy(gameObject, timeDelay);
    }

    public void InstantiateModel()
    {
        Instantiate(bulletInfo.model, transform.position, Quaternion.identity, transform);
    }

    public void OnAddingForce()
    {
        rb.AddForce(bulletInfo.moveSpeed * direction, ForceMode.VelocityChange);      
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("EnemyMinion"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null) 
            {
                damageable.TakeDamage(gunDamage);
                Destroy(gameObject);
            }
        }
    }
}
