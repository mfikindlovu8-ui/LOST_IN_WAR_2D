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
        // Read real health data
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        // Update UI hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < health);

            if (i < health)
            {
                hearts[i].texture = fullHeart;
            }
        }

        // Death check
        if (!isDead && health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameOverSceneName);
    }
}