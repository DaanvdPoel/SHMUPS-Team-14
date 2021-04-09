using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLuke : MonoBehaviour
{
    private float bulletSpeed = 7;

    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (bulletSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
