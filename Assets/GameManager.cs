using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Boss spawning")]
    private float bossTime;
    [SerializeField] private float bossTimer;
    [SerializeField] private GameObject boss;


    void Start()
    {
        
    }

    void Update()
    {
        bossTime = bossTime + Time.deltaTime;

        if(bossTime >= bossTimer)
        {
            SpawnBoss();
        }

    }

    private void SpawnBoss()
    {

    }
}
