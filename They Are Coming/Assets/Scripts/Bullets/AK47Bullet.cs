using UnityEngine;

public class AK47Bullet : Bullet
{
    private void OnEnable()
    {
        InitializeVariables();     
        InstantiateModel();
        OnAddingForce();
    }

    private void Update() 
    {
        DestroyBullet();
    }
}
