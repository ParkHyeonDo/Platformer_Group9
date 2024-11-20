using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Equipable,
    Consumable
}
public enum ConsumableType
{
    Health
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float valut;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public ItemType itemType;
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject item;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}