using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Animation")]
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 input;
    private bool isWalking;

    public Vector2 lastMoveDir = Vector2.down;

    // ✅ REQUIRED FOR GUN
    public Vector2 currentInput;

    [Header("Combat")]
    public Transform attackPoint;
    public float radius = 1f;
    public int damage = 1;
    public LayerMask enemies;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }

    public void Move()
    {
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // ✅ STORE INPUT FOR GUN
        currentInput = input;

        Vector3 move = new Vector3(input.x, input.y, 0f).normalized;

        if (input != Vector2.zero)
        {
            lastMoveDir = input.normalized;
        }

        transform.position += move * moveSpeed * Time.deltaTime;

        isWalking = input != Vector2.zero;

        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);
        }
        else
        {
            animator.SetFloat("MoveX", lastMoveDir.x);
            animator.SetFloat("MoveY", lastMoveDir.y);
        }
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