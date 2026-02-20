using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Level2"); 
    }
}