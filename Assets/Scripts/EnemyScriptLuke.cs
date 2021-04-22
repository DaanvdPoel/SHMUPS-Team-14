﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptLuke : MonoBehaviour
{
    // NIET AANKOMEN!!!
    // ik meen het, niet aankomen, als je dit wilt gebruiken maak je gewoon een kopie van dit scrip
    // yours sincerely,
    // Luke

    [SerializeField] private int health;
    private bool canMove;
    private float distance = 1;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float minSpeed = 5;

    private GameObject target;
    private Vector3 enemyPos;
    private Quaternion enemyRot;

    [SerializeField] private ParticleSystem bullet;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private int attackSound;

    private float timer;
    private float shootTimer;

    private float randomX;
    private float randomZ;
    private Vector3 offset;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distance * (maxSpeed * Time.deltaTime));
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

    private void Shoot()
    {
        if (bullet != null)
        {

            if (attackSound > -0)
            {
                audioManager.PlaySound(attackSound);
            }
            bullet.Play();
        }

        //enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //enemyRot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        //Instantiate(bullet, enemyPos, enemyRot);
        shootTimer = 5;
    }

    private void RandomizePosition()
    {
        randomX = Random.Range(-5, 5);
        {
            randomZ = Random.Range(-2, 2);
            offset = new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y, gameObject.transform.position.z + randomZ);
            float randomS = Random.Range(minSpeed, maxSpeed);
            maxSpeed = randomS;
        }

    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!other.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }
}