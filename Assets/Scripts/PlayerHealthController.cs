using UnityEngine;


public class PlayerHealthController : MonoBehaviour
{
    #region Properties

    
    [SerializeField] private int healthInitial = 3;

    
    private int healthCurrent;

    #endregion

    #region Initialisation methods

    
    void Start()
    {
        
        ResetHealth();
    }
  public void ResetHealth()
    {
      
        healthCurrent = healthInitial;
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

       
        if (healthCurrent > healthInitial)
        {
            
            ResetHealth();
        }
    }

    #endregion
}
