using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Stage[] Stages;
    private StageLoader _stageLoader;
    private int _curStageIdx = 0;
    public Text stageNum;

    public GameObject Player;
    public CameraFollow CameraFollowScript;
    public StageProgress stageProgress;

    private void Start()
    {
        _stageLoader = GetComponent<StageLoader>();

        SaveData loadedData = SaveSystem.LoadGame();
        if (loadedData != null)
        {
            _curStageIdx = loadedData.CurrentStageIndex;

            PlayerStats playerStats = Player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.currentHealth = Mathf.Clamp(loadedData.PlayerHealth, 0, playerStats.maxHealth);
            }
        }

        ChangeStage(_curStageIdx);
    }

    private void ChangeStage(int curStageIdx)
    {
        if (curStageIdx < 0 || curStageIdx >= Stages.Length)
        {
            return;
        }

        GameObject loadedStage = _stageLoader.LoadStage(Stages[curStageIdx].Prefab);

        Player.transform.position = Stages[curStageIdx].StartPosition;

        if (CameraFollowScript != null)
        {
            CameraFollowScript.SetPlayer(Player.transform);

            var collisionObject = loadedStage.transform.Find("Collision");
            if (collisionObject != null)
            {
                var mapBoundary = collisionObject.GetComponent<TilemapCollider2D>();
                if (mapBoundary != null)
                {
                    CameraFollowScript.SetMapBoundary(mapBoundary);
                }
            }
        }

        if (stageProgress != null)
        {
            //stageProgress.stageMonster.InitializeStageMonsters();
        }
        _curStageIdx = curStageIdx;
    }

    public void NextStage()
    {
        int nextStageIdx = _curStageIdx + 1;
        stageNum.text = (_curStageIdx + 1).ToString();

        if (nextStageIdx < Stages.Length)
        {
            ChangeStage(nextStageIdx);
        }
    }

    private void SaveCurData(int stageIdx)
    {
        PlayerStats playerStats = Player.GetComponent<PlayerStats>();

        SaveData saveData = new SaveData
        {
            CurrentStageIndex = stageIdx,
            PlayerHealth = playerStats != null ? playerStats.currentHealth : 1000
        };

        SaveSystem.WriteSaveData(saveData);
    }
}
