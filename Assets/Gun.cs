using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float shootForce = 10f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // 🔥 ALWAYS SHOOT HORIZONTALLY
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        rb.linearVelocity = new Vector2(direction * shootForce, 0f);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.damage = damage;
        }
    }
}