using UnityEngine;

public class EPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    public float speed = 2f;

    private Transform currentPoint;
    private Animator anim;

    void Start()
    {
        currentPoint = pointB.transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Direction to target
        Vector2 direction = (currentPoint.position - transform.position).normalized;

        // Move
        transform.position = Vector2.MoveTowards(
            transform.position,
            currentPoint.position,
            speed * Time.deltaTime
        );

        // Switch points
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.2f)
        {
            currentPoint = (currentPoint == pointB.transform) ? pointA.transform : pointB.transform;
        }

        // Clean animation direction
        Vector2 dir;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            dir = new Vector2(Mathf.Sign(direction.x), 0);
        else
            dir = new Vector2(0, Mathf.Sign(direction.y));

        anim.SetFloat("MoveX", dir.x);
        anim.SetFloat("MoveY", dir.y);
    }

    void OnDrawGizmos()
    {
        if (pointA == null || pointB == null) return;

        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}