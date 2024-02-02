using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public float currentHealth;
    public float maximumHealth;

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    public bool isInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamage;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmount)
    {

        if (currentHealth == 0)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        } else
        {
            OnDamage.Invoke();
        }
    }
}
