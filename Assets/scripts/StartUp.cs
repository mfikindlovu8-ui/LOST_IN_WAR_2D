using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
   public void Play()
    {
        SceneManager.LoadScene("Environment");
            }


    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
