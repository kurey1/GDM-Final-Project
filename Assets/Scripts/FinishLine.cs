using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public CanvasGroup levelCompleteGroup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelCompleteGroup.alpha = 1f;
            levelCompleteGroup.interactable = true;
            levelCompleteGroup.blocksRaycasts = true;

            Time.timeScale = 0f; 
        }
    }
}


