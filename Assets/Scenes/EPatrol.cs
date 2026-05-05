using UnityEngine;

public class EPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    public float speed = 2f;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    private Transform currentPoint;
    private Vector3 startPos;

    private Animator anim;

    void Start()
    {
        currentPoint = pointB.transform;
        startPos = transform.position;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = (currentPoint.position - transform.position).normalized;

        // Move
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentPoint.position,
            speed * Time.deltaTime
        );

        // SNAP direction cleanly (no drift issues)
        Vector2 dir;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            dir = new Vector2(Mathf.Sign(direction.x), 0);
        }
        else
        {
            dir = new Vector2(0, Mathf.Sign(direction.y));
        }

        // Animator
        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);
    

        // Switch patrol points
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = (currentPoint == pointB.transform) ? pointA.transform : pointB.transform;
        }

        // Floating effect (visual only)
        Vector3 pos = transform.position;
        pos.y = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = pos;
    }

    void OnDrawGizmos()
    {
        if (pointA == null || pointB == null) return;

        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}