using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    [HideInInspector] public PlayerController Controller;
    [HideInInspector] public PlayerAnimationController PlayerAnim;
    [HideInInspector] public PlayerInventory Inventory;
    [HideInInspector] public CharacterStatHandler Stat;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Inventory = GetComponent<PlayerInventory>();
        Stat = GetComponent<CharacterStatHandler>();
        PlayerAnim = GetComponent<PlayerAnimationController>();
    }
}
