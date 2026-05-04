using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float shootForce = 10f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    private Movement playerMovement;

    void Start()
    {
        playerMovement = transform.root.GetComponent<Movement>();
    }

    void Update()
    {
        HandleFlip();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void HandleFlip()
    {
       
        if (playerMovement.lastMoveDir.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (playerMovement.lastMoveDir.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = playerMovement.lastMoveDir;

        // safety fallback
        if (direction == Vector2.zero)
            direction = Vector2.right;

        rb.linearVelocity = direction.normalized * shootForce;

        // rotate bullet visually to match direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.damage = damage;
        }
    }
}