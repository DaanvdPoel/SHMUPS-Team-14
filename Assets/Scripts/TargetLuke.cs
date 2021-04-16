using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLuke : MonoBehaviour
{
    private float randomX;
    private float randomZ;
    private float timer;
    private Vector3 targetPos;

    [SerializeField] private GameObject player;

    void Start()
    {
        randomX = 0;
        randomZ = 0;
        targetPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            RandomizePosition();
            timer = 0.3f;
        }
    }

    private void RandomizePosition()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z - 10);
        randomX = Random.Range(-3, 3);
        randomZ = Random.Range(-2, 2);
        targetPos = new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y, gameObject.transform.position.z + randomZ);
        gameObject.transform.position = targetPos;
    }
}
