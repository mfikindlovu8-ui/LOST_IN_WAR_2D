using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


