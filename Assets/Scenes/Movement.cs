using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform attackPoint;
    public float radius = 1f;
    public int damage = 1;
    public LayerMask enemies;

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }

    void Move()
    {
        Vector3 movDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movDirection.y += 1f;

        if (Input.GetKey(KeyCode.S))
            movDirection.y -= 1f;

        if (Input.GetKey(KeyCode.A))
            movDirection.x -= 1f;

        if (Input.GetKey(KeyCode.D))
            movDirection.x += 1f;

        transform.position += movDirection.normalized * moveSpeed * Time.deltaTime;
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(
            attackPoint.position,
            radius,
            enemies
        );

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");

            EnemyHealth health = enemyGameobject.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
