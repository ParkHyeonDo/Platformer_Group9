using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterStat", menuName = "Stat/CharacterStat", order = 1)]
public class CharacterStat : ScriptableObject
{
    [Header("���� ����")]
    public int Health;
    public int Mana;
    public int Damage;
    public float Speed;
    public float JumpForce;

    public bool HaveKnockback;
    public float KnockbackForce;

}
