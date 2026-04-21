using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string WelldoneScene = "Well Done Scene"; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.name); 

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the exit!");
            SceneManager.LoadScene(WelldoneScene); 
        }
    }
}