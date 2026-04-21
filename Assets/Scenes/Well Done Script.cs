using UnityEngine;
using UnityEngine.SceneManagement;

public class WellDoneScript : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}   