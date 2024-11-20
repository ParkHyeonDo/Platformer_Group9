using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerStats stats;
    public PlayerInventory inventory;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        stats = GetComponent<PlayerStats>();
        inventory = GetComponent<PlayerInventory>();   

    }

    public void Exam()
    {
        GameManager.Instance.Player.stats.currentHealth = 0;
    }
}
