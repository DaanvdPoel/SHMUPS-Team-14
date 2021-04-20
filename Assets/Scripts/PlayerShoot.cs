using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem bullets;
    void Start()
    {
        
    }

    void Update()
    {       
        Shoot();       
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bullets.Play();
            bullets.loop = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            bullets.Stop();
        }
    }
}
