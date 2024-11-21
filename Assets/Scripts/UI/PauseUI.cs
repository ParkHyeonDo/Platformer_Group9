using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public InputAction pauseAction;

    
    public void OnDestroy()
    {
        pauseAction.performed -= OnPause;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
            pauseUI.SetActive(!pauseUI.activeSelf);
    }
}