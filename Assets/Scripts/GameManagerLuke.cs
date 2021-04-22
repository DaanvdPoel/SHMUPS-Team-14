using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLuke : MonoBehaviour
{
    //void Start()
    //{

    //}
    //void Update()
    //{
        
    //}

    public void Restart()
    {
        StartCoroutine(Restarting());
    }

    public void Win()
    {
        StartCoroutine(Winning());
    }

    private IEnumerator Restarting()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Winning()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("WinScreen");
    }

}
