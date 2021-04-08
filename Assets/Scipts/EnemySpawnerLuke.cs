using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLuke : MonoBehaviour
{
    [SerializeField] private float spawnCooldown = 1;
    [SerializeField] private int spawnCount = 2;
    [SerializeField] private GameObject enemyType;

    private float spawnTimer;

    void Start()
    {
        
    }

    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer = spawnTimer - Time.deltaTime;
        }

        if (spawnCount > 0)
        {
            if (spawnTimer <= 0)
            {
                Instantiate(enemyType);
                spawnTimer = spawnCooldown;
                spawnCount--;
            }
        }
    }
}
