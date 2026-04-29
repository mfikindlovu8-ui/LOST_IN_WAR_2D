using UnityEngine;

public class EPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    public float speed = 2f;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    private Rigidbody2D rb;
    private Transform currentPoint;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

        startPos = transform.position;
    }

    void Update()
    {
        // Direction towards target point
        Vector2 direction = (currentPoint.position - transform.position).normalized;

        
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        // Switch patrol points when close
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = (currentPoint == pointB.transform) ? pointA.transform : pointB.transform;
            Flip();
        }

        // Floating effect (visual only, does NOT affect physics movement)
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = pos;
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmos()
    {
        if (pointA == null || pointB == null) return;

        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}
