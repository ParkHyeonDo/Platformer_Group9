using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData data;
    public string GetInteractPrompt() => $"{data.itemName}\n{data.description}";
}