using UnityEngine;

public class NextStageDoor : MonoBehaviour
{
    private bool isEnabled = false;

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