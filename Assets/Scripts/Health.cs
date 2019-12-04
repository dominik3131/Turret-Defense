using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField]
    private int currentHealth;

    public event System.Action<float> onHealthChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        onHealthChanged((float)currentHealth / (float)maxHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            WaveSpanner.EnemiesAlive--;
        }
    }
}
