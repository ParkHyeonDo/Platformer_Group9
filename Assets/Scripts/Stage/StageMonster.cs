using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StageMonster : MonoBehaviour
{
    //private List<Monster> activeMonsters = new List<Monster>();

    //public int ActiveMonsterCount => activeMonsters.Count;

    //public void InitializeStageMonsters()
    //{
    //    activeMonsters.Clear();

    //    Monster[] monsters = FindObjectsOfType<Monster>();
    //    foreach (var monster in monsters)
    //    {
    //        activeMonsters.Add(monster);
    //    }
    //}

    //private void OnEnable()
    //{
    //    Monster.Die = HandleMonster;
    //}

    //private void OnDisable()
    //{
    //    Monster.Die -= HandleMonster;
    //}

    //private void HandleMonster(Monster monster)
    //{
    //    if (activeMonsters.Contains(monster))
    //    {
    //        activeMonsters.Remove(monster);
    //    }
    //}
}
