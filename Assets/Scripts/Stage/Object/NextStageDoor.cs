using UnityEngine;

public class NextStageDoor : MonoBehaviour, IInteractable
{
    private bool isEnabled = true;

    public void EnableDoor()
    {
        isEnabled = true;
    }

    public void Interact()
    {
        if (!isEnabled)
        {
            return;
        }

        StageManager stageManager = FindObjectOfType<StageManager>();
        if (stageManager != null)
        {
            stageManager.NextStage();
        }
    }
}