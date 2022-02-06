using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeToSpawm;

    private Vector3 spawnPosition;
    private Vector3 direction;
    private bool isSpawning;
    private float timer;
    private int totalEnemiesSpawned;

    private void OnEnable()
    {
       
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        isSpawning = true;
        direction = Vector3.back;
        timer = 0f;
        totalEnemiesSpawned = 0;

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
        if (timer >= timeToSpawm)
        {
            spawnPosition = RandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            totalEnemiesSpawned += 1;
            timeToSpawm += 0.2f;
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
        if (totalEnemiesSpawned >= 100)
        {
            isSpawning = false;
        }
    }
}
