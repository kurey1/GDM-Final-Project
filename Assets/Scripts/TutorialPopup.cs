using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        popup.SetActive(true);  
        Time.timeScale = 0f;    
    }

    public void ClosePopup()
    {
        popup.SetActive(false); 
        Time.timeScale = 1f;    
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            ClosePopup();
        }
    }
}