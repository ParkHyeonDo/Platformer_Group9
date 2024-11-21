using UnityEngine;
using System;

public class StageProgress : MonoBehaviour
{
    public StageMonster stageMonster;
    public GameObject RewardBox;
    public GameObject NextStageDoor;

    public event Action OnStageClear;
    private bool stageCleared;

    private void Start()
    {
        if (stageMonster != null)
        {
            //stageMonster.InitializeStageMonsters();
        }

        if (RewardBox != null)
        {
            RewardBox.SetActive(false); 
        }

        if (NextStageDoor != null)
        {
            NextStageDoor.SetActive(false); 
        }
    }

    private void Update()
    {
        //if (!stageCleared && stageMonster.ActiveMonsterCount == 0) 
        //{
        //    stageCleared = true;
        //    HandleStageClear();
        //}
    }

    private void HandleStageClear()
    {
        OnStageClear?.Invoke();

        if (RewardBox != null)
        {
            RewardBox.SetActive(true);
        }

        if (NextStageDoor != null)
        {
            NextStageDoor.SetActive(true);
        }
    }
}