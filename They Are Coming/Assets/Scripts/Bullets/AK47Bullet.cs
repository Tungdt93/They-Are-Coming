using UnityEngine;

public class AK47Bullet : Bullet
{
    private Vector3 direction;

    public override void InitializeBullet(Vector3 position, Transform bulletStorage)
    {
        Instantiate(this.gameObject, position, Quaternion.identity, bulletStorage);
    }

    public override void InitializeVariables()
    {
        rb = GetComponent<Rigidbody>();
        timeDelay = 3f;
        direction = Vector3.forward;
    }

    private void OnEnable()
    {
        InitializeVariables();     
        InstantiateModel();
        OnAddingForce(direction);
    }

    private void Update() 
    {
        DestroyBullet();
    }


}
