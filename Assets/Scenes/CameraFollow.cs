using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float smoothSpeed = 5f;

 
            void Start()
    {
        offset = transform.position - player.position;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
