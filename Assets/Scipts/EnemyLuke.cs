using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLuke : MonoBehaviour
{
    private int health;
    private float randomCooldown;
    private bool canMove;
    private float distance = 1;
    private float speed = 10;

    private GameObject target;
    //private Playerclass player;


    void Start()
    {
        canMove = true;
        target = GameObject.FindGameObjectWithTag("Target");
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distance * (speed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
