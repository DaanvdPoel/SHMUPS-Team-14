using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private GameObject fadein;
    [SerializeField] private Slider progressbar;

    [Header("References")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MapManager mapManager;

    private void Start()
    {
        progressbar.maxValue = bossTimer;
    }

    void Update()
    {
        if (bossSpawned == false)
        {
            progressbar.value = bossTime;
            bossTime = bossTime + Time.deltaTime;
        }

        if(bossTime >= bossTimer && bossSpawned == false)
        {
            bossSpawned = true;
            SpawnBoss();
        }

    }

    public void SpawnBoss()
    {
        if (boss != null)
        {
            mapManager.bossFight = true;
            boss.SetActive(true);
            audioManager.bossFightMusic = true;
            audioManager.PlayBossFightMusic();
        }else if(boss == null)
        {
            fadein.SetActive(true);
            Invoke("LoadNextLevel", 4f);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
