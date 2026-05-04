using UnityEngine;

public class AIChase : MonoBehaviour
{

    public GameObject player;

    [Header("Movement")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    [Header("Detection")]
    public float detectionRange = 5f;

    private bool isChasing = false;

    // Patrol points
    public Transform pointA;
    public Transform pointB;
    private Transform currentPoint;

    void Start()
    {
        currentPoint = pointB;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        
        if (distance < detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.transform.position,
            chaseSpeed * Time.deltaTime
        );
    }

    void Patrol()
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
}


