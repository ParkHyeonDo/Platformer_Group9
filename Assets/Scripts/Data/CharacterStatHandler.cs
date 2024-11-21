﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat playerBaseStat;
    [HideInInspector]public CharacterStat PlayerCurrentStat;

    protected virtual void Start()
    {
        PlayerCurrentStat = new CharacterStat();
        PlayerCurrentStat.Health = playerBaseStat.Health;
        PlayerCurrentStat.Mana = playerBaseStat.Mana;
        PlayerCurrentStat.Speed = playerBaseStat.Speed;
        PlayerCurrentStat.JumpForce = playerBaseStat.JumpForce;
    }
}

