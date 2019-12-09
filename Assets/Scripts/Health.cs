using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField]
    private float currentHealth;

    public event System.Action<float> onHealthChanged = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        onHealthChanged(currentHealth / maxHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
