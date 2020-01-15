﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField]
    protected float currentHealth;

    public event System.Action<float> OnHealthChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        OnHealthChanged(( float )currentHealth / ( float )maxHealth);
        if ( currentHealth <= 0 )
        {
            DeathActions();
            Destroy(gameObject);
        }
    }
    public virtual void DeathActions()
    {
        LevelMoneyManager.instance.AddMoney(gameObject.GetComponent<Enemy>().moneyValue);
        WaveSpanner.EnemiesAlive--;
    }
    public void Revive()
    {
        currentHealth = maxHealth;
    }
}
