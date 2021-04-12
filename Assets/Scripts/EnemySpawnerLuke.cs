using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLuke : MonoBehaviour
{
    [SerializeField] private float spawnCooldown = 1;
    [SerializeField] private int spawnCount = 2;
    [SerializeField] private GameObject enemyType;

    private Vector3 enemySpawnPos;
    private Quaternion enemySpawnRot;

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
                Position();
                Instantiate(enemyType, enemySpawnPos, enemySpawnRot);
                spawnTimer = spawnCooldown;
                spawnCount--;
            }
        }
    }

    private void Position()
    {
        enemySpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        enemySpawnRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
    }

}
