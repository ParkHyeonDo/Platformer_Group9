using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour
{
    public shop[] slots;
    public GameObject ShopInventoryWindow;
    public Transform slotPanel;

    public TextMeshProUGUI upgradeStatusText; 
    public Button upgradeButton;

    private int upgradeLevel = 0; 
    private float successRate = 0.9f; 
    private int upgradeCost = 100;
    private const int maxUpgradeLevel = 4;

    [Header("Select Item")]
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemprice;

    public GameObject BuyButton;
    public GameObject SellButton;
    public GameObject UpgradeButton;

    private PlayerStats playerStats;
    private ItemType itemType;
    private ItemObject itemObject;

    public List<ItemData> shopItems = new List<ItemData>();
    // Start is called before the first frame update
    void Start()
    {
        ShopInventoryWindow.SetActive(false);
        slots = new shop[slotPanel.childCount];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<shop>();
            slots[i].index = i;
            slots[i].shopinventory = this;
        }
        UpdateUpgradeButtonStatus();
    }

  

    void Update()
    {
        
    }

    public void OnUpgradeButtonClick()
    {
        // 최대 강화 단계에 도달했는지 확인
        if (upgradeLevel >= maxUpgradeLevel)
        {
            upgradeStatusText.text = "최대 강화 단계에 도달했습니다.";
            return;
        }

        
        //if (playerInventory.gold >= upgradeCost)
        //{
        //    upgradeStatusText.text = "소지금이 부족합니다!";
        //    return;
        //}

        //// 소지금 차감
        //playerInventory.gold -= upgradeCost;

        // 강화 성공 여부 확인
        if (Random.value <= successRate) // 성공
        {
            upgradeLevel++;
            successRate -= 0.1f; 
            upgradeCost += 100; 
            upgradeStatusText.text = $"강화 성공! 현재 강화 단계: {upgradeLevel}";
        }
        else // 실패
        {
            upgradeStatusText.text = "강화 실패! 아이템은 안전합니다.";
        }

        UpdateUpgradeButtonStatus();
    }

    private void UpdateUpgradeButtonStatus()
    {
        // 최대 강화 단계에서 버튼 비활성화
        if (upgradeLevel >= maxUpgradeLevel)
        {
            upgradeButton.interactable = false;
            upgradeStatusText.text = "더 이상 강화를 할 수 없습니다.";
        }
    }
}

