using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector3 movDirection;
    private bool isWalking;

    public Vector2 lastMoveDir = Vector2.down;

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
            Vector2 input = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            Vector3 movDirection = new Vector3(input.x, input.y, 0f);

            // update facing direction ONLY when moving
            if (input != Vector2.zero)
            {
                lastMoveDir = input.normalized;
            }

            transform.position += movDirection.normalized * moveSpeed * Time.deltaTime;

            isWalking = input != Vector2.zero;
            animator.SetBool("isWalking", isWalking);
            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);

            movDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                movDirection.y += 1f;

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                movDirection.y -= 1f;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                movDirection.x -= 1f;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                movDirection.x += 1f;

            isWalking = movDirection != Vector3.zero;

            if (isWalking)
            {
                lastMoveDir = movDirection;
            }

            transform.position += movDirection.normalized * moveSpeed * Time.deltaTime;



            animator.SetBool("isWalking", isWalking);

            if (isWalking)
            {
                animator.SetFloat("MoveX", movDirection.x);
                animator.SetFloat("MoveY", movDirection.y);
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
