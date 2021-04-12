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
        if (Input.GetMouseButtonDown(0) && bullets.isPlaying == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        bullets.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other);
        }
    }
}
