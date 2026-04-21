using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public RawImage[] hearts;
    public Texture fullHeart;

    public HealthSystem playerHealth;

    public string gameOverSceneName = "GameOver";

    private bool isDead = false;

    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
                hearts[i].texture = fullHeart;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        // Check death
        if (!isDead && health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Optional: stop player movement visually
        Time.timeScale = 1f;

        SceneManager.LoadScene(gameOverSceneName);
    }
 
}

