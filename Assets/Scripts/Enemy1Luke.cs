using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Luke : MonoBehaviour
{
    private int health = 5;
    private bool canMove;
    private float distance = 1;
    [SerializeField] private float speed = 10;

    private GameObject target;
    private Vector3 enemyPos;
    private Quaternion enemyRot;
    //private Playerclass player;

    [SerializeField] private GameObject bullet;
    private float shootTimer;


    void Start()
    {
        canMove = true;
        target = GameObject.FindGameObjectWithTag("Target");
        //player = GameObject.FindGameObjectWithTag("Player");

        shootTimer = 0f;
    }

    void Update()
    {
        if (canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distance * (speed * Time.deltaTime));
        }

        if (shootTimer > 0)
        {
            shootTimer = shootTimer - Time.deltaTime;
        }

        if (shootTimer <= 0)
        {
            Shoot();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
        }
    }

    private void Shoot()
    {
        enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        enemyRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        Instantiate(bullet, enemyPos, enemyRot);
        shootTimer = 5;
    }
}
