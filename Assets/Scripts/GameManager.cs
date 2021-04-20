using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Boss spawning")]
    private float bossTime;
    private bool bossSpawned = false;
    [SerializeField] private float bossTimer;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossHealthbarUI;

    [Header("References")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MapManager mapManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (bossSpawned == false)
        {
            bossTime = bossTime + Time.deltaTime;
        }

        if(bossTime >= bossTimer && bossSpawned == false)
        {
            bossSpawned = true;
            SpawnBoss();
        }

    }

    private void SpawnBoss()
    {
        boss.SetActive(true);
        mapManager.bossFight = true;
        audioManager.bossFightMusic = true;
        audioManager.PlayBossFightMusic();
    }
}
