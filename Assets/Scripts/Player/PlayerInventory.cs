using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public List<ItemData> inventory = new List<ItemData>();
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameManager.Instance.Player.GetComponent<PlayerStats>();
    }

    public void AddItem(ItemData item)
    {
        inventory.Add(item);
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
                    Debug.Log("체력이 이미 최대입니다. Consumable 아이템을 사용할 수 없습니다.");
                    return;  
                }
                playerStats.UseItem(item);  
            }


        }
       
    }
}
