using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    #region Properties

    
    [SerializeField] private int maxHealth = 3;

    
    private int healthCurrent;

    #endregion

    #region Initialisation methods

    
    void Start()
    {
        
        ResetHealth();
    }
  public void ResetHealth()
    {
      
        healthCurrent = maxHealth;
    }

    #endregion

    #region Gameplay methods

    
    public void TakeDamage(int damageAmount)
    {
       
        healthCurrent -= damageAmount;

       
        if (healthCurrent <= 0)
        {
            
            Destroy(gameObject);

            
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

    #endregion
}
