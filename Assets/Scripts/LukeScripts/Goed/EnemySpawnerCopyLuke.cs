using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCopyLuke : MonoBehaviour
{
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float delayTime;
    [SerializeField] private int spawnCount;
    [SerializeField] private GameObject enemyType;

    private GameObject target;

    private Vector3 enemySpawnPos;
    private Quaternion enemySpawnRot;

    private float spawnTimer;
    private int randomPos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SpawnerTarget");
    }

    void Update()
    {
        if (delayTime > 0)
        {
            delayTime = delayTime - Time.deltaTime;
        }

        if (delayTime <= 0)
        {
            if (spawnTimer > 0)
            {
                spawnTimer = spawnTimer - Time.deltaTime;
            }

            if (spawnCount > 0)
            {
                if (spawnTimer <= 0)
                {
                    EnemyPosition();
                    Instantiate(enemyType, enemySpawnPos, enemySpawnRot);
                    SetNewPosition();
                    spawnTimer = spawnCooldown;
                    spawnCount--;
                }
            }
        }

        if (spawnCount == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void EnemyPosition()
    {
        enemySpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        enemySpawnRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
    }

    private void SetNewPosition()
    {
        transform.position = new Vector3(target.transform.position.x - randomPos, target.transform.position.y, target.transform.position.z);
        randomPos = Random.Range(-30, 30);
        transform.position = new Vector3(target.transform.position.x + randomPos, target.transform.position.y, target.transform.position.z);
    }
}
