using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePauseActions : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}