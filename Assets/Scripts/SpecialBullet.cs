using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    private bool canMove;
    private float distance = 1;
    private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float despawnTimer;

    void Start()
    {
        canMove = true;
        target = GameObject.FindGameObjectWithTag("Target");
    }


    void Update()
    {
        if (canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distance * (speed * Time.deltaTime));
        }

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
