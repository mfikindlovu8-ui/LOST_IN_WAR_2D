using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string WellDoneSceneName = "Well Done Scene";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered the trigger: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the exit!");
            SceneManager.LoadScene("Well Done Scene");
        }
    }
}