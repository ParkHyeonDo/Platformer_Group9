using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public PlayerController Controller;
    public PlayerAnimationController PlayerAnim;
    public PlayerStats Stats;
    public PlayerInventory Inventory;
    public CharacterStatHandler Stat;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Stats = GetComponent<PlayerStats>();
        Inventory = GetComponent<PlayerInventory>();
        Stat = GetComponent<CharacterStatHandler>();
        PlayerAnim = GetComponent<PlayerAnimationController>();
    }

    public void Exam()
    {
        GameManager.Instance.Player.Stats.currentHealth = 0;
    }
}
