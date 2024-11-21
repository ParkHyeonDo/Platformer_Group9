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
            Debug.Log($"{item.itemName}��(��) ����մϴ�.");

            if (item.itemType == ItemType.Consumable)
            {
                if (playerStats.currentHealth == playerStats.maxHealth)
                {
                    Debug.Log("ü���� �̹� �ִ��Դϴ�. Consumable �������� ����� �� �����ϴ�.");
                    return;  
                }
                playerStats.UseItem(item);  
            }


        }
       
    }
}
