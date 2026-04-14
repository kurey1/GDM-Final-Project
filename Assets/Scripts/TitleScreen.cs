using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");   // Change to your actual first level name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}