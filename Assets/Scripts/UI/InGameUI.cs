using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject pauseUI;
    public void PauseBtn()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }
}
