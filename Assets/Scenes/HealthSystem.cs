//using UnityEngine;

//public class HealthSystem : MonoBehaviour
//{

//    public int health;
//    public int maxHealth = 3;

//    public SpriteRenderer playerSr;
//    public Movement playerMovement;


<<<<<<< HEAD
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        //health = maxHealth;
    }

    void Update()
    {
=======
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        health = maxHealth;
//    }

//    void Update()
//    {
>>>>>>> 63af2c425d29a7c01506822376e3be939a006406

//        if (Input.GetKeyDown(KeyCode.D))
//        {
//            // Damage(1);
//        }

//        if (Input.GetKeyDown(KeyCode.H))

<<<<<<< HEAD
        {
            // Heal(1);
        }
    }
    public void TakeDamage(int amount)

    {
        health -= amount;
        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
        }
    }
}

=======
//        {
//            // Heal(1);
//        }
//    }
//    public void TakeDamage(int amount)

//    {
//        health -= amount;
//        if (health <= 0)
//        {
//            playerSr.enabled = false;
//            playerMovement.enabled = false;
//        }
//    }
//}

>>>>>>> 63af2c425d29a7c01506822376e3be939a006406
