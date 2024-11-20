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
    private void Awake() // 초기화시
    {
        UpdateItemName();
    }

    public ItemType itemType; // 아이템 유형
    public string itemName;   // 아이템 이름

   

    // 장착 아이템 관련 속성
    public int baseAttackPower = 0; // 기본 공격력
    public int upgradeLevel = 0;    // 강화 레벨
    public int maxUpgradeLevel = 5; // 최대 강화 레벨
    public int CurrentAttackPower => baseAttackPower + upgradeLevel;
    public string ItemDisplayName => itemName + GetUpgradeSuffix();

    private string GetUpgradeSuffix()
    {
        return upgradeLevel > 0 ? $" ++{upgradeLevel}" : "";
    }

    // 인벤토리나 shop에서 강화하면 정보 받아서 저장 및 display 표시예정, 우선 단순 강화 로직만.
    public void UpgradeItem()
    {
        if (upgradeLevel < 5)
        {
            upgradeLevel++;
            UpdateItemName(); // 이름 업데이트
            Debug.Log($"아이템 강화 완료: {ItemDisplayName}, 공격력: {CurrentAttackPower}");
        }
        else
        {
            Debug.Log("강화가 최대 레벨에 도달했습니다!");
        }
    }

    // 소비 아이템 관련 속성
    public ConsumableType consumableType; // 회복 유형
    public int healthRecovery = 0;        // 체력 회복량
    public int manaRecovery = 0;          // 마나 회복량
    public bool isFullRecovery = false;

    // Health
    // 1) Apple :5
    // 2) Bread : 20
    // 3) Meat : 50
    // 4) Health potion : 100
    // Mana
    // 1) Beer : 20
    // 2) Mans potion : 100

    // 체력과 마나 회복 아이템 로직
    public void Use(GameObject player)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            if (consumableType == ConsumableType.Health)
            {
                int recoveryAmount = isFullRecovery ? playerStats.maxHealth : healthRecovery;
                playerStats.RecoverHealth(recoveryAmount);
                Debug.Log($"{itemName}: 체력을 {recoveryAmount} 회복했습니다!");
            }
            else if (consumableType == ConsumableType.Mana)
            {
                int recoveryAmount = isFullRecovery ? playerStats.maxMana : manaRecovery;
                playerStats.RecoverMana(recoveryAmount);
                Debug.Log($"{itemName}: 마나를 {recoveryAmount} 회복했습니다!");
            }
        }
        else
        {
            Debug.LogWarning("PlayerStats 스크립트를 찾을 수 없습니다.");
        }
    }

    private void UpdateItemName()
    {
        gameObject.name = ItemDisplayName;
    }

    // 플레이어에게 적용
    //public void ApplyToPlayer(GameObject player)
    //{
    //    PlayerStats playerStats = player.GetComponent<PlayerStats>();

    //    if (playerStats != null)
    //    {
    //        playerStats.EquipWeapon(this);
    //        Debug.Log($"{ItemDisplayName}을(를) 장착했습니다! 현재 공격력: {CurrentAttackPower}");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("PlayerStats 스크립트가 플레이어에게 없습니다.");
    //    }
    //}

}


