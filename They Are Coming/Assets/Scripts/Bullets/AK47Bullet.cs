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
    }

    private void Update() 
    {
        DestroyBullet();
    }
}
