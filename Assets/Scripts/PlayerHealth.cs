using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private float healthRegainerationAmount;
    [SerializeField] private float timeBetweenHealthRegaineration;
    [SerializeField] private GameManager gameManager;
    private float time;
    private float currentHealth;



    void Start()
    {
        ResetHealth();
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
    }

    private void Update()
    {
        if(currentHealth < maxHealth)
        {
            time = time + Time.deltaTime;
        }

        if(time >= timeBetweenHealthRegaineration)
        {
             Heal(healthRegainerationAmount);
            time = 0;
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameManager.PlayerDied();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        slider.value = currentHealth;
        if (currentHealth > maxHealth)
        {
            ResetHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tentacle"))
        {
            TakeDamage(15);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }
}
