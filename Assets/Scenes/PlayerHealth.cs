//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerHealth : MonoBehaviour
//{

//    public int health;
//    public int maxHealth;

//    public Sprite emptyHeart;
//    public Sprite fullHeart;
//    public Image[] hearts;

//    public HealthSystem playerHealth;


//    Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;

        //maxHealth = playerHealth.maxHealth;
=======
//    Update is called once per frame
//    void Update()
//    {
//        health = playerHealth.health;
//        maxHealth = playerHealth.maxHealth;
>>>>>>> 63af2c425d29a7c01506822376e3be939a006406

//        for (int i = 0; i < hearts.Length; i++)
//        {
//            if (i < health)
//            {
//                hearts[i].sprite = fullHeart;
//            }
//            else
//            {
//                hearts[i].sprite = emptyHeart;
//            }

//            if (i < maxHealth)
//            {
//                hearts[i].enabled = true;
//            }
//            else
//            {
//                hearts[i].enabled = false;
//            }

//        }
//    }
//}
