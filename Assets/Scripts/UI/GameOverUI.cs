using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;

    public void RetryBtn()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("Title");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
