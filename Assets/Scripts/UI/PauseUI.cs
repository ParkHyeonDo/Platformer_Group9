using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;

    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }
    public void Quit()
    {
        SceneManager.LoadScene("Title");
    }
}