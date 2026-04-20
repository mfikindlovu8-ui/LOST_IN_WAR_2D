using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    
    public float health;
    public float currentHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < health)
        {
            currentHealth = health;

        }
        if(health >= 0)
        {
            Debug.Log("Enemy Defeated");
        }
    }
}
