using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
  public void Resume ()
    {
        SceneManager.LoadScene("Environment")

    }
   public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu")
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Environment")
    }
    
    
}
