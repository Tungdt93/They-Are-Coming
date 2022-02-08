using UnityEngine;

public class AK47Bullet : Bullet
{
     private void OnEnable()
    {
        InitializeVariables();     
        InstantiateModel();
        OnAddingForce();
    }

    private void InitializeVariables()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.forward;
        timeDelay = 3f;
    }

    private void InstantiateModel()
    {
        Instantiate(bulletInfo.model, transform.position, Quaternion.identity, transform);
    }

    private void Update() 
    {
        DestroyBullet();
    }
}
