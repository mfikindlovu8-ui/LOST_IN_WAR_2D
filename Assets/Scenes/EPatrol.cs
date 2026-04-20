using UnityEngine;

public class EPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    public float degreePerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;


    Vector3 posOffset = new Vector3();
    Vector3 temPos = new Vector3();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        posOffset = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        temPos = posOffset;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = temPos;

        Vector3 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector3(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector3(-speed, 0);
        }

        if (Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
                {
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
    }
    private void flip() 
    {
      Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void  OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}
