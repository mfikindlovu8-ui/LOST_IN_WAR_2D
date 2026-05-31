using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Animation")]
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 input;
    private Vector2 moveDir;
    private bool isWalking;

    public Vector2 lastMoveDir = Vector2.down;

    // For gun / external scripts
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
        // INPUT
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        currentInput = input;

        // NORMALIZE movement for consistent speed & animation
        moveDir = input.normalized;

        // store last valid direction
        if (input != Vector2.zero)
        {
            lastMoveDir = moveDir;
        }

        // APPLY MOVEMENT
        transform.position += (Vector3)moveDir * moveSpeed * Time.deltaTime;

        isWalking = input != Vector2.zero;

        animator.SetBool("isWalking", isWalking);

        // 🔥 IMPORTANT PART FOR BLEND TREE
        Vector2 animDir = isWalking ? moveDir : lastMoveDir;

        animator.SetFloat("MoveX", animDir.x);
        animator.SetFloat("MoveY", animDir.y);
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