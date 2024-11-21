using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditorInternal.VersionControl;
using static UnityEditor.Progress;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{

    public List<ItemData> inventory = new List<ItemData>();
    private PlayerStats playerStats;

    public TextMeshProUGUI itemCountText;
    public int gold = 1000; 
    public TextMeshProUGUI goldText;

    private void Start()
    {
        playerStats = GameManager.Instance.Player.GetComponent<PlayerStats>();
    }

    public void AddItem(ItemData item)
    {
        inventory.Add(item);
        UpdateInventoryUI();
    }

    
    public void UseItem(ItemData item)
    {
        if (item != null)
        {
            Debug.Log($"{item.itemName}을(를) 사용합니다.");

            if (item.itemType == ItemType.Consumable)
            {
                if (playerStats.currentHealth == playerStats.maxHealth)
                {
                    Debug.Log("체력이 이미 최대입니다. 아이템을 사용할 수 없습니다.");
                    return;  
                }
                playerStats.UseItem(item);
                RemoveItem(item);
                UpdateInventoryUI();
            }
        }
    }
    public void RemoveItem(ItemData item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log($"{item.itemName}이(가) 사용되었습니다.");
        }
    }

    private void UpdateInventoryUI()
    {
        if (inventory.Count > 0 && itemCountText != null)
        {
            var groupedItems = inventory.GroupBy(item => item.itemName);

            foreach (var group in groupedItems)
            {
                itemCountText.text = $"{group.Key} x{group.Count()}";
            }
        }
    }

    public void UpdateGold(int amount)
    {
        gold += amount; 
        gold = Mathf.Max(gold, 0); 
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = $"Gold: {gold}";
        }
    }
}
