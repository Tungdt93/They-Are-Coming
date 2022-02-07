using UnityEngine;

public abstract class PlayerUnit : MonoBehaviour
{
    public GameObject playerMinionPrefab;
    public GameObject spawnPosition;
    public GameObject visual;
    public Transform weaponHolder;
    public Rigidbody rb;
    public CharacterController controller;
    public PlayerUnitInfomation unitInfo;
    public Weapon weapon;

    public Vector3 velocity;
    public Vector3 sideDirection;

    public bool isControlling;

    public void GenerateFirstMinion()
    {
        Instantiate(playerMinionPrefab, spawnPosition.transform.position, Quaternion.identity, transform);
    }

    public void GenerateNewMinions(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector2 randomRange = Random.insideUnitCircle;
            Vector3 randomPosition = new Vector3(spawnPosition.transform.position.x + randomRange.x,
                spawnPosition.transform.position.y,
                spawnPosition.transform.position.z + randomRange.y);
            Instantiate(playerMinionPrefab, randomPosition, Quaternion.identity, transform);
        }       
    }

    public Vector3 RandomPosition(Vector3 center, float radius)
    {
        Vector3 position;
        position.x = center.x + Random.Range(-radius, radius);
        position.y = center.y;
        position.z = center.z + Random.Range(-radius, radius);
        return position;
    }
}
