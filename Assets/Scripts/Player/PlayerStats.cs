using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void RecoverHealth(int amount) //for health ui
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        CharacterCurrentStat.Health = currentHealth;
        Debug.Log($"���� ü��: {currentHealth}/{maxHealth}");
    }
    public void UseItem(ItemData item)
    {
        // Consumable �����۸� ��� ����
        if (item.itemType == ItemType.Consumable)
        {
            // consumables �迭�� ��� �ְų� null���� Ȯ��
            if (item.consumables == null || item.consumables.Length == 0)
            {
                Debug.LogWarning($"{item.itemName}���� ���� ������ �Һ� ȿ���� �����ϴ�.");
                return;
            }

            foreach (var consumable in item.consumables)
            {
                if (consumable.type == ConsumableType.Health)
                {
                    RecoverHealth((int)consumable.valut);
                    Debug.Log($"{item.itemName} ��� - ü�� ȸ��: {consumable.valut}");
                }
            }
        }

    }
}