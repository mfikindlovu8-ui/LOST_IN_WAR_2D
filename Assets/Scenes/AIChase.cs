using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    [Header("Detection")]
    public float detectionRange = 5f;

    public Transform pointA;
    public Transform pointB;
    private Transform currentPoint;

    private Animator anim;

    void Start()
    {
        currentPoint = pointB;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        bool isChasing = distance < detectionRange;

        Vector2 oldPos = transform.position;

        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                chaseSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                currentPoint.position,
                patrolSpeed * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.2f)
            {
                currentPoint = (currentPoint == pointA) ? pointB : pointA;
            }
        }

        // Movement delta
        Vector2 movement = (Vector2)transform.position - oldPos;

        // SNAP direction (CRITICAL FIX)
        Vector2 dir = Vector2.zero;

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            dir = new Vector2(Mathf.Sign(movement.x), 0);
        }
        else if (movement.magnitude > 0.01f)
        {
            dir = new Vector2(0, Mathf.Sign(movement.y));
        }

        // Animator
        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);
        anim.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude > 0.01f)
        {
            anim.SetFloat("LastMoveX", dir.x);
            anim.SetFloat("LastMoveY", dir.y);
        }
    }
}