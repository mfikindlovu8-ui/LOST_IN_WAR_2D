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
    [SerializeField] Animator gunAnimator;

    [Header("Player Reference")]
    [SerializeField] Movement playerMovement;
    [SerializeField] Transform playerTransform;

    [Header("Follow Settings")]
    [SerializeField] Vector3 offset;

    [Header("UI")]
    [SerializeField] Image bulletImage;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject outOfAmmoText;

    void Start()
    {
        currentAmmo = maxAmmo;

        UpdateUI();

        if (outOfAmmoText != null)
        {
            outOfAmmoText.SetActive(false);
        }
    }

    void Update()
    {
        FollowPlayer();
        UpdateAnimation();

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

    void UpdateAnimation()
    {
        if (gunAnimator == null || playerMovement == null) return;

        Vector2 dir = playerMovement.lastMoveDir;

        if (dir == Vector2.zero)
            dir = Vector2.down;

        gunAnimator.SetFloat("moveX", dir.x);
        gunAnimator.SetFloat("moveY", dir.y);
    }

    void Shoot()
    {
        // No ammo
        if (currentAmmo <= 0)
        {
            if (outOfAmmoText != null)
            {
                outOfAmmoText.SetActive(true);
            }

            return;
        }

        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        Vector2 direction = playerMovement.lastMoveDir;

        if (direction == Vector2.zero)
            direction = Vector2.down;

        rb.linearVelocity = direction.normalized * shootForce;

        Bullet b = bullet.GetComponent<Bullet>();

        if (b != null)
        {
            b.damage = damage;
        }

        // Reduce ammo
        currentAmmo--;

        UpdateUI();
    }

    void UpdateUI()
    {
        // Update ammo number
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString();
        }

        // Show/hide out of ammo message
        if (outOfAmmoText != null)
        {
            outOfAmmoText.SetActive(currentAmmo <= 0);
        }
    }

    // Optional function for ammo pickups later
    public void AddAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        UpdateUI();
    }
}