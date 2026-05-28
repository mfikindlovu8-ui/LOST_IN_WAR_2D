using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("Ammo")]
    public int ammoAmount = 10;

    [Header("Floating Effect")]
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float floatHeight = 0.15f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating animation
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(
            startPos.x,
            newY,
            startPos.z
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gun gun = collision.GetComponentInChildren<Gun>();

            if (gun != null)
            {
                gun.AddAmmo(ammoAmount);
            }

            Destroy(gameObject);
        }
    }
}