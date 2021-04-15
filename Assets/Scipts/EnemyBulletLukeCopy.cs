using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLukeCopy : MonoBehaviour
{
    private float bulletSpeed = 7;

    [SerializeField] private float despawnTimer;

    void Update()
    {
        gameObject.transform.position += Vector3.back * bulletSpeed * Time.deltaTime;

        if (despawnTimer > 0)
        {
            despawnTimer = despawnTimer - Time.deltaTime;
        }

        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
