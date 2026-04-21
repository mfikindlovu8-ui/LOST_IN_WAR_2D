using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int health;
    public int maxHealth = 3;

    public SpriteRenderer playerSr;
    public Movement playerMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    
    public void TakeDamage(int amount)

    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    
}

