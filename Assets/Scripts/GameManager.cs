using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Boss spawning")]
    private float bossTime;
    private bool bossSpawned = false;
    [SerializeField] private float bossTimer;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossHealthbarUI;

    [Header("UI screens")]
    [SerializeField] private GameObject playerDiedScreen;
    [SerializeField] private GameObject playerNextLevelScreen;
    [SerializeField] private GameObject playerWinScreen;

    [Header("References")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MapManager mapManager;


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
        if (boss != null)
        {
            mapManager.bossFight = true;
            boss.SetActive(true);
            audioManager.bossFightMusic = true;
            audioManager.PlayBossFightMusic();
        }else if(boss == null)
        {
            Invoke("LoadNextLevel", 3f);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
