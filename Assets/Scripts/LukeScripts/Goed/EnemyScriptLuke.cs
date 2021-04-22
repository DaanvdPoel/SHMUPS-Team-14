using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptLuke : MonoBehaviour
{
    [SerializeField] private int health;
    private bool canMove;
    private float distance = 1;
    [SerializeField] private float speed = 10;

    private GameObject target;
    private Vector3 enemyPos;
    private Quaternion enemyRot;

    [SerializeField] private ParticleSystem bullet;
    private float timer;
    private float shootTimer;

    private float randomX;
    private float randomZ;
    private Vector3 offset;


    void Start()
    {
        canMove = true;
        target = GameObject.FindGameObjectWithTag("FarTarget");

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

        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            RandomizePosition();
            timer = 1f;
        }

        transform.Rotate(0, 0 - 50 * Time.deltaTime, 0);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(-1);
        }
    }

    private void Shoot()
    {
        bullet.Play();

        //enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //enemyRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        //Instantiate(bullet, enemyPos, enemyRot);
        shootTimer = 5;
    }

    private void RandomizePosition()
    {
        randomX = Random.Range(-5, 5);
        randomZ = Random.Range(-2, 2);
        offset = new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y, gameObject.transform.position.z + randomZ);
        int randomS = Random.Range(5, 10);
        speed = randomS;
    }

    public void TakeDamage(int damage)
    {
        health = health + damage;
    }
}
