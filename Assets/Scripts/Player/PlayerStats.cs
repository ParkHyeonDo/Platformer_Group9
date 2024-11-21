using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int baseattack = 1;

    public ItemData itemdata;
    public Action addItem;


    private void Start()
    {
        currentHealth = maxHealth;

    }

    public void RecoverHealth(int amount) //for health ui
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"현재 체력: {currentHealth}/{maxHealth}");
    }
    public void UseItem(ItemData item)
    {
        // Consumable 아이템만 사용 가능
        if (item.itemType == ItemType.Consumable)
        {
            foreach (var consumable in item.consumables)
            {
                if (consumable.type == ConsumableType.Health)
                {
                    RecoverHealth((int)consumable.valut); 
                    Debug.Log($"{item.itemName} 사용 - 체력 회복: {consumable.valut}");
                }
            }
        }

    }
}