using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        Vector3 movDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movDirection.y += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movDirection.y -= 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movDirection.x -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movDirection.x += 1f;
        }

        transform.position += movDirection.normalized * moveSpeed * Time.deltaTime;

    }


        public void  attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

            foreach  (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }

        
    }
       // Update is called once per frame

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    }

