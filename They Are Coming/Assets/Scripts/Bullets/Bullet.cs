using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public BulletInformation bulletInfo;
    public Rigidbody rb;
    public float timeDelay;
    public int gunDamage;

    public void DestroyBullet() 
    {
        Destroy(gameObject, timeDelay);
    }

    public abstract void InitializeVariables();

    public void InstantiateModel()
    {
        Instantiate(bulletInfo.model, transform.position, Quaternion.identity, transform);
    }

    public abstract void InitializeBullet(Vector3 position, Transform bulletStorage);

    public void OnAddingForce(Vector3 bulletDirection)
    {
        rb.AddForce(bulletInfo.moveSpeed * bulletDirection, ForceMode.VelocityChange);      
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
