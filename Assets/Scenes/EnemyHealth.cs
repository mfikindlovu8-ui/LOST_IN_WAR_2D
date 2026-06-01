using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("Death Effect")]
    [SerializeField] private GameObject deathEffect;

    [Header("Loot Drop")]
    [SerializeField] private GameObject bulletPickup;
    [SerializeField] private GameObject heartPickup;
    [SerializeField] private int minDrop = 1;
    [SerializeField] private int maxDrop = 3;
    [SerializeField][Range(0f, 1f)] private float heartDropChance = 0.25f;

    [Header("Knockback")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float knockbackForce = 6f;
    [SerializeField] private Transform player;

    [Header("Flash Effect")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.1f;

    [Header("Heart UI")]
    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject healthUI;

    [Header("Player Detection")]
    [SerializeField] private float showDistance = 5f;

    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;

        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        UpdateHearts();
    }

    void Update()
    {
        if (healthUI == null || player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        healthUI.SetActive(distance <= showDistance);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Enemy HP: " + currentHealth);

        StartCoroutine(FlashRed());
        UpdateHearts();

        ApplyKnockback();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ApplyKnockback()
    {
        if (rb == null || player == null) return;

        Vector2 direction = ((Vector2)transform.position - (Vector2)player.position).normalized;

        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }

    void Die()
    {
        Debug.Log("Enemy died");

        if (deathEffect != null)
        {
            Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
            Instantiate(deathEffect, spawnPos, Quaternion.identity);
        }

        DropLoot();

        Destroy(gameObject);
    }

    void DropLoot()
    {
        // Drop bullets
        if (bulletPickup != null)
        {
            int amount = Random.Range(minDrop, maxDrop + 1);

            for (int i = 0; i < amount; i++)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-0.3f, 0.3f),
                    Random.Range(-0.3f, 0.3f),
                    0);

                Instantiate(bulletPickup, transform.position + offset, Quaternion.identity);
            }
        }

        // Chance to drop a heart
        if (heartPickup != null && Random.value <= heartDropChance)
        {
            Vector3 heartOffset = new Vector3(
                Random.Range(-0.3f, 0.3f),
                Random.Range(-0.3f, 0.3f),
                0);

            Instantiate(heartPickup, transform.position + heartOffset, Quaternion.identity);
        }
    }

    void UpdateHearts()
    {
        if (hearts == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
                hearts[i].enabled = i < currentHealth;
        }
    }

    IEnumerator FlashRed()
    {
        if (spriteRenderer == null) yield break;

        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}