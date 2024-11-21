using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    public Stage[] Stages;
    private StageLoader _stageLoader;
    private int _curStageIdx = 0;
    public GameObject Player;
    public CameraFollow CameraFollowScript;
    public StageProgress stageProgress;

    private void Start()
    {
        _stageLoader = GetComponent<StageLoader>();
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

        if (nextStageIdx < Stages.Length)
        {
            ChangeStage(nextStageIdx);
        }
    }
}
