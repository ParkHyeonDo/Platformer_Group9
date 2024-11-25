using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStats : CharacterStatHandler
{
    public int maxHealth = 1000;
    public int currentHealth;
    public int baseattack = 1;

    public ItemData itemdata;
    public Action addItem;


    private void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
        CharacterCurrentStat.Health = maxHealth;

    }

    public void RecoverHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        CharacterCurrentStat.Health = currentHealth;
        Debug.Log($"현재 체력: {currentHealth}/{maxHealth}");
    }
    public void UseItem(ItemData item)
    {
        if (item.itemType == ItemType.Consumable)
        {
            if (item.consumables == null || item.consumables.Length == 0)
            {
                Debug.LogWarning($"{item.itemName}에는 적용 가능한 소비 효과가 없습니다.");
                return;
            }

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