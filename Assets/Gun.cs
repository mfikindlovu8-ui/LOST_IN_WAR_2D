using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int damage = 1;
    [SerializeField] float shootForce = 10f;

    [Header("Ammo")]
    [SerializeField] int maxAmmo = 12;
    int currentAmmo;

    [Header("References")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootSound;

    [Header("Animation")]
    [SerializeField] Animator animator;

    [Header("Player Reference")]
    [SerializeField] Movement playerMovement;
    [SerializeField] Transform playerTransform;

    [Header("Follow Settings")]
    [SerializeField] Vector3 offset;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject outOfAmmoText;

    private Vector2 aimDirection = Vector2.down;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateUI();

        if (outOfAmmoText != null)
            outOfAmmoText.SetActive(false);

        if (playerMovement == null)
            Debug.LogWarning("Gun: PlayerMovement is NOT assigned in Inspector!");

        if (playerTransform == null)
            Debug.LogWarning("Gun: PlayerTransform is NOT assigned in Inspector!");

        if (firePoint == null)
            Debug.LogWarning("Gun: FirePoint is NOT assigned in Inspector!");

        if (audioSource == null)
            Debug.LogWarning("Gun: AudioSource is NOT assigned in Inspector!");

        if (shootSound == null)
            Debug.LogWarning("Gun: ShootSound is NOT assigned in Inspector!");

        if (animator == null)
            Debug.LogWarning("Gun: Animator is NOT assigned in Inspector!");
    }

    void LateUpdate()
    {
        FollowPlayer();
        ReadDirection();
        ApplyDirection();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FollowPlayer()
    {
        if (playerTransform == null) return;

        transform.position = playerTransform.position + offset;
    }

    void ReadDirection()
    {
        if (playerMovement == null)
        {
            aimDirection = Vector2.down;
            return;
        }

        Vector2 dir = playerMovement.lastMoveDir;

        if (dir == Vector2.zero)
            dir = Vector2.down;

        aimDirection = dir.normalized;
    }

    void ApplyDirection()
    {
        if (animator == null) return;

        // These names must match your Blend Tree parameters
        animator.SetFloat("MoveY", aimDirection.y);
        animator.SetFloat("MoveX", aimDirection.x);

      
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            if (outOfAmmoText != null)
                outOfAmmoText.SetActive(true);

            return;
        }

        if (bulletPrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Bullet has no Rigidbody2D!");
            return;
        }

        rb.linearVelocity = aimDirection * shootForce;

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.damage = damage;
            b.SetDirection(aimDirection);
        }

        currentAmmo--;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (ammoText != null)
            ammoText.text = currentAmmo.ToString();

        if (outOfAmmoText != null)
            outOfAmmoText.SetActive(currentAmmo <= 0);
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > maxAmmo)
            currentAmmo = maxAmmo;

        UpdateUI();
    }
}