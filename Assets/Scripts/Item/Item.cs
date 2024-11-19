using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}
public enum ConsumableType
{
    Health,
    Mana,
  
}


public class Item : MonoBehaviour
{
    private void Awake() // �ʱ�ȭ��
    {
        UpdateItemName();
    }

    public ItemType itemType; // ������ ����
    public string itemName;   // ������ �̸�

   

    // ���� ������ ���� �Ӽ�
    public int baseAttackPower = 0; // �⺻ ���ݷ�
    public int upgradeLevel = 0;    // ��ȭ ����
    public int maxUpgradeLevel = 5; // �ִ� ��ȭ ����
    public int CurrentAttackPower => baseAttackPower + upgradeLevel;
    public string ItemDisplayName => itemName + GetUpgradeSuffix();

    private string GetUpgradeSuffix()
    {
        return upgradeLevel > 0 ? $" ++{upgradeLevel}" : "";
    }

    // �κ��丮�� shop���� ��ȭ�ϸ� ���� �޾Ƽ� ���� �� display ǥ�ÿ���, �켱 �ܼ� ��ȭ ������.
    public void UpgradeItem()
    {
        if (upgradeLevel < 5)
        {
            upgradeLevel++;
            UpdateItemName(); // �̸� ������Ʈ
            Debug.Log($"������ ��ȭ �Ϸ�: {ItemDisplayName}, ���ݷ�: {CurrentAttackPower}");
        }
        else
        {
            Debug.Log("��ȭ�� �ִ� ������ �����߽��ϴ�!");
        }
    }

    // �Һ� ������ ���� �Ӽ�
    public ConsumableType consumableType; // ȸ�� ����
    public int healthRecovery = 0;        // ü�� ȸ����
    public int manaRecovery = 0;          // ���� ȸ����
    public bool isFullRecovery = false;

    // Health
    // 1) Apple :5
    // 2) Bread : 20
    // 3) Meat : 50
    // 4) Health potion : 100
    // Mana
    // 1) Beer : 20
    // 2) Mans potion : 100

    // ü�°� ���� ȸ�� ������ ����
    public void Use(GameObject player)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            if (consumableType == ConsumableType.Health)
            {
                int recoveryAmount = isFullRecovery ? playerStats.maxHealth : healthRecovery;
                playerStats.RecoverHealth(recoveryAmount);
                Debug.Log($"{itemName}: ü���� {recoveryAmount} ȸ���߽��ϴ�!");
            }
            else if (consumableType == ConsumableType.Mana)
            {
                int recoveryAmount = isFullRecovery ? playerStats.maxMana : manaRecovery;
                playerStats.RecoverMana(recoveryAmount);
                Debug.Log($"{itemName}: ������ {recoveryAmount} ȸ���߽��ϴ�!");
            }
        }
        else
        {
            Debug.LogWarning("PlayerStats ��ũ��Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    private void UpdateItemName()
    {
        gameObject.name = ItemDisplayName;
    }

    // �÷��̾�� ����
    //public void ApplyToPlayer(GameObject player)
    //{
    //    PlayerStats playerStats = player.GetComponent<PlayerStats>();

    //    if (playerStats != null)
    //    {
    //        playerStats.EquipWeapon(this);
    //        Debug.Log($"{ItemDisplayName}��(��) �����߽��ϴ�! ���� ���ݷ�: {CurrentAttackPower}");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("PlayerStats ��ũ��Ʈ�� �÷��̾�� �����ϴ�.");
    //    }
    //}

}


