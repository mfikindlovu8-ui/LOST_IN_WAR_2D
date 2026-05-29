
using UnityEngine;

public class MoonPulse : MonoBehaviour
{
    public float pulseSpeed = 1f;
    public float pulseAmount = 0.1f;

    private Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float scale = (Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = originalScale * scale;
        
    }
}
