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
        currentPoint = pointB != null ? pointB : pointA;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        bool isChasing = distance < detectionRange;

        Vector2 target;
        float speed;

        // ---------------- STATE ----------------
        if (isChasing)
        {
            target = player.transform.position;
            speed = chaseSpeed;
        }
        else
        {
            target = currentPoint.position;
            speed = patrolSpeed;
        }

        // ---------------- MOVE ----------------
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        // Switch patrol points safely
        if (!isChasing &&
            Vector2.SqrMagnitude((Vector2)transform.position - (Vector2)currentPoint.position) < 0.04f)
        {
            currentPoint = (currentPoint == pointA) ? pointB : pointA;
        }

        // ---------------- CLEAN DIRECTION (KEY FIX) ----------------
        Vector2 direction = (target - (Vector2)transform.position).normalized;

        Vector2 dir = Vector2.zero;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            dir = new Vector2(Mathf.Sign(direction.x), 0);
        else
            dir = new Vector2(0, Mathf.Sign(direction.y));

        // ---------------- ANIMATION ----------------
        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);
        anim.SetFloat("Speed", speed);
    }
}