using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;

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
