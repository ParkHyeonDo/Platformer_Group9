using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [HideInInspector] public PlayerController Controller;
    [HideInInspector] public PlayerAnimationController PlayerAnim;
    //[HideInInspector] public PlayerStats Stats;
    [HideInInspector] public PlayerInventory Inventory;
    [HideInInspector] public CharacterStatHandler Stat;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        //Stats = GetComponent<PlayerStats>();
        Inventory = GetComponent<PlayerInventory>();
        Stat = GetComponent<CharacterStatHandler>();
        PlayerAnim = GetComponent<PlayerAnimationController>();
    }

    public void Exam()
    {
        //GameManager.Instance.Player.Stats.currentHealth = 0;
    }
}
