using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float respawnCooldown;
    [SerializeField] private int enemiesSpawned;
    [SerializeField] private int maxEnemiesSpawned;

    private Vector3 spawnPosition;
    private Vector3 direction;
    private bool isSpawning;
    private float timeToSpawn;
    private float timer;

    private void OnEnable()
    {
       
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        isSpawning = true;
        direction = Vector3.back;
        timer = 0f;
    }

    private void Update()
    {
        Move();      
        SpawnEnemy();
        LimitEnemiesSpawned();
    }

    private void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * direction);
    }

    private void SpawnEnemy()
    {
        if (!isSpawning)
        {
            return;
        }

        timer = Time.time;
        if (timer >= timeToSpawn)
        {
            spawnPosition = RandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, transform.rotation * Quaternion.Euler(0f, 180f, 0f), this.transform);
            enemiesSpawned += 1;
            timeToSpawn += respawnCooldown;
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float xPosition = Random.Range(-9.5f, 9.6f);
        Vector3 newSpawnPosition = new Vector3(transform.position.x + xPosition,
            transform.position.y,
            transform.position.z);
        return newSpawnPosition;
    }

    private void LimitEnemiesSpawned()
    {
        if (enemiesSpawned >= maxEnemiesSpawned)
        {
            isSpawning = false;
        }
    }
}
