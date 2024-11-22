using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat characterBaseStat;
    [HideInInspector]public CharacterStat CharacterCurrentStat;

    protected virtual void Awake()
    {
        CharacterCurrentStat = new CharacterStat();
        CharacterCurrentStat.Health = characterBaseStat.Health;
        CharacterCurrentStat.Mana = characterBaseStat.Mana;
        CharacterCurrentStat.Damage = characterBaseStat.Damage;
        CharacterCurrentStat.Speed = characterBaseStat.Speed;
        CharacterCurrentStat.JumpForce = characterBaseStat.JumpForce;

        CharacterCurrentStat.HaveKnockback = characterBaseStat.HaveKnockback;
        CharacterCurrentStat.KnockbackForce = characterBaseStat.KnockbackForce;
    }
}

