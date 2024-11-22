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
        SaveData newGameData = new SaveData
        {
            CurrentStageIndex = 0,
            PlayerHealth = 1000
        };

        SaveSystem.WriteSaveData(newGameData);
        SceneManager.LoadScene("SampleScene");
        System.GC.Collect();

    }

    public void LoadGame() 
    {
        SaveData loadedData = SaveSystem.LoadGame();
        if (loadedData != null)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Option() 
    {
    
    }

    public void Quit() 
    {
        Application.Quit();
    }
}

