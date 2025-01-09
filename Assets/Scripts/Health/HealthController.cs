using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    public UnityEvent onDied;
    public UnityEvent onDamaged;
    public UnityEvent onHealthChange;

    public float RemainingHealthPer{get{return currentHealth/maxHealth;}}

    public bool isInvincible{get;set;}

    public void TakeDamage(float damage)
    {
        if(currentHealth==0)
        {
            return;
        }
        if(isInvincible)
        {
            return;
        }
        currentHealth-=damage;
        onHealthChange.Invoke();
        if(currentHealth<0)
        {
            currentHealth=0;
        }
        if(currentHealth==0)
        {
            onDied.Invoke();
        }
        else
        {
            onDamaged.Invoke();
        }
    }

    public void AddHealth(float health)
    {
        if(currentHealth==maxHealth)
        {
            return;
        }
        currentHealth+=health;
        onHealthChange.Invoke();
        if(currentHealth>maxHealth)
        {
            currentHealth=maxHealth;
        }
    }
}
