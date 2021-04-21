using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkEnemy : MonoBehaviour
{
    [SerializeField] private int health;
    private bool canMove;
    private float distance = 1;
    [SerializeField] private float speed = 10;

    private GameObject target;
    private Vector3 enemyPos;
    private Quaternion enemyRot;

    [SerializeField] private ParticleSystem bullet;
    [SerializeField] private float timer;
    private float time;


    void Start()
    {
        canMove = true;
        target = GameObject.FindGameObjectWithTag("FarTarget");
    }

    void Update()
    {
        if (canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distance * (speed * Time.deltaTime));
        }


        time = time + Time.deltaTime;


        if (time >= timer)
        {
            Shoot();
            time = 0;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Bullet"))
        {
            health = health - 10;
        }
    }
    
    private void Shoot()
    {
        bullet.Play();

        //enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //enemyRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        //Instantiate(bullet, enemyPos, enemyRot);
        //shootTimer = 5;
    }
}
