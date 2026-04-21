using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Environment");
            }

    public void Exit()
    {
        Application.Quit();
    }
}
