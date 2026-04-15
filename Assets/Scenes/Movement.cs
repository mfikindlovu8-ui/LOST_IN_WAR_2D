using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

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

        // Update is called once per frame

    }

