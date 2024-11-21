using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject NewGameButton;
    public GameObject LoadButton;
    public GameObject OptionButton;
    public GameObject QuitButton;

    private void Start()
    {
        StartUISettings();
    }

    private void StartUISettings()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
        System.GC.Collect();

    }

    public void LoadGame() 
    {
    
    }

    public void Option() 
    {
    
    }

    public void Quit() 
    {
        Application.Quit();
    }
}

