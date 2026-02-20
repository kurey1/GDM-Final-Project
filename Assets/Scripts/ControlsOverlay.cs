using UnityEngine;

public class ControlsOverlay : MonoBehaviour
{
    public CanvasGroup controlsGroup;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            controlsGroup.alpha = 0f;
            controlsGroup.interactable = false;
            controlsGroup.blocksRaycasts = false;
        }
    }
}