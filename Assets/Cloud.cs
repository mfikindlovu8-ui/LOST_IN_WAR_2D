
using UnityEngine;

public class Cloud: MonoBehaviour
{
    public float strength = 0.5f;
    public float distance = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Floating motion using a fixed speed float newY =startingPosition.y + (Time.time * strenth) * distance;
        transform.position =new Vector3(transform.position.x, transform.position.z);
        //Horizontal movement always moving to the left) transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
    }
}
