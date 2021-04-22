using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyCannon : MonoBehaviour
{
    private Vector3 enemyPos;
    private Quaternion enemyRot;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float offset;
    private float shootTimer;

    void Start()
    {
        shootTimer = 0f;
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
    }
    private void Shoot()
    {
        enemyPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        enemyRot = new Quaternion(0, -90 + offset, 0, 0);
        Instantiate(bullet, enemyPos, enemyRot);
        shootTimer = 5;
    }
}
