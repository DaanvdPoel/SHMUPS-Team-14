using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth;

    private GameManagerLuke gameManager;
    private int healthCurrent;


    void Start()
    {
        ResetHealth();
        gameManager = FindObjectOfType<GameManagerLuke>();
    }
    public void ResetHealth()
    {
        healthCurrent = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;

        if (healthCurrent <= 0)
        {
            gameManager.Restart();
        }
    }

    public void Heal(int healAmount)
    {
        healthCurrent += healAmount;

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
        TakeDamage(10);
    }
}
