using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    [SerializeField] private int currentHealth, maxHealth;

    private PlayerController thePlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        thePlayer = GetComponent<PlayerController>();
        
        currentHealth = maxHealth;
        UIController.instance.HealthDisplay(currentHealth, maxHealth);
    }

    public void DamagePlayer()
    {
        currentHealth--;
        if(currentHealth<=0)
        {
            currentHealth = 0;
            LifeController.instance.Respawn();
            
        }
        UIController.instance.HealthDisplay(currentHealth,maxHealth);
    }

    public void AddHealth(int amountToAdd)
    {
        currentHealth += amountToAdd;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.HealthDisplay(currentHealth,maxHealth);
    }
}
