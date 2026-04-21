using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float moveX;
    float moveY;
    float movementspeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {




    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0);

        transform.Translate(movement * movementspeed * Time.deltaTime);

    }
}






