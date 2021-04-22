using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private Slider slider;

    private int healthCurrent;


    void Start()
    {
        ResetHealth();
        slider.maxValue = maxHealth;
        slider.value = slider.maxValue;
    }
    public void ResetHealth()
    {
        healthCurrent = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        slider.value = healthCurrent;

        if (healthCurrent <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;
        slider.value = healthCurrent;
        if (healthCurrent > maxHealth)
        {
            ResetHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tentacle"))
        {
            TakeDamage(3);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }
    }
}
