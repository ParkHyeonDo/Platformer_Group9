using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Stage[] Stages;
    private StageLoader _stageLoader;
    private int _curStageIdx = 0;
    public GameObject Player;

    private void Start()
    {
        _stageLoader = new StageLoader();
        ChangeStage(_curStageIdx);
    }

    private void ChangeStage(int curStageIdx)
    {
        if (curStageIdx < 0 || curStageIdx >= Stages.Length)
        {
            return;
        }

        _stageLoader.LoadStage(Stages[curStageIdx].Prefab);

        Player.transform.position = Stages[curStageIdx].StartPosition;
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
