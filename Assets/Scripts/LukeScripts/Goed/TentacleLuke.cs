using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleLuke : MonoBehaviour
{
    [SerializeField] private int health;

    private Vector3 enemyPos;
    private Quaternion enemyRot;

    [SerializeField] private ParticleSystem bullet;
    private float shootTimer;

    private GameObject boss;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        shootTimer = 5;
    }

    void Update()
    {
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
            boss.GetComponent<BossLuke>().Tentacle();
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
        }
    }

    private void Shoot()
    {
        //enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //enemyRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);        
        //Instantiate(bullet, enemyPos, enemyRot);
        //shootTimer = 5;

        bullet.Play();

        Debug.Log("pew");
    }
}
