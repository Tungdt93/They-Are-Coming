using UnityEngine;

public class AK47BulletSpawner : BulletSpawner
{
    private Vector3 direction;     

    private void OnEnable() 
    {
        InitializeVariables();
    }

    public override void InitializeVariables()
    {
        weapon = GetComponent<Weapon>();
        bullet = weapon.bulletType;
        direction = Vector3.forward;
    }

    public override void InitializeBullet(Vector3 position)
    {
        GameObject newBullet = Instantiate(bullet.gameObject, position, Quaternion.identity, GameManager.Instance.BulletStorgage.transform);
        newBullet.GetComponent<Bullet>().OnAddingForce(direction);
    }
}
