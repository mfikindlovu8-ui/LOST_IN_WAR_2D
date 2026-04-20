using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

public int maxHealth = 100;
public int currentHealth;

public HealthSystem healthBar;

// Start is called before the first frame update
void Start()
    {
        currentHealth = maxHealth;
    }

    // Upadate is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
}