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
        // �ִ� ��ȭ �ܰ迡 �����ߴ��� Ȯ��
        if (upgradeLevel >= maxUpgradeLevel)
        {
            upgradeStatusText.text = "�ִ� ��ȭ �ܰ迡 �����߽��ϴ�.";
            return;
        }

        
        //if (playerInventory.gold >= upgradeCost)
        //{
        //    upgradeStatusText.text = "�������� �����մϴ�!";
        //    return;
        //}

        //// ������ ����
        //playerInventory.gold -= upgradeCost;

        // ��ȭ ���� ���� Ȯ��
        if (Random.value <= successRate) // ����
        {
            upgradeLevel++;
            successRate -= 0.1f; 
            upgradeCost += 100; 
            upgradeStatusText.text = $"��ȭ ����! ���� ��ȭ �ܰ�: {upgradeLevel}";
        }
        else // ����
        {
            upgradeStatusText.text = "��ȭ ����! �������� �����մϴ�.";
        }

        UpdateUpgradeButtonStatus();
    }

    private void UpdateUpgradeButtonStatus()
    {
        // �ִ� ��ȭ �ܰ迡�� ��ư ��Ȱ��ȭ
        if (upgradeLevel >= maxUpgradeLevel)
        {
            upgradeButton.interactable = false;
            upgradeStatusText.text = "�� �̻� ��ȭ�� �� �� �����ϴ�.";
        }
    }
}

