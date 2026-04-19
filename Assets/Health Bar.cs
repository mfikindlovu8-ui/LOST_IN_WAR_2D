using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void SetHealth(float health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        slider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        SetHealth(currentHealth - damage);
    }

    public void UpdateHealthBar(int current, int max)
    {
        slider.maxValue = max;
        slider.value = current;
    }
}



    