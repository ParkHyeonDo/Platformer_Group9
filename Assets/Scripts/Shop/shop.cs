using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour , IInteractable
{
    public ItemData item;
    public GameObject shopinventory;
    [HideInInspector]public ShopInventory inventory;
    public int index;
    public bool equipped;
    public int quantity;


    public void Interact() 
    {
        if (shopinventory != null)
        {
            shopinventory.gameObject.SetActive(true);
            Debug.Log("shop");
        }
    }
}
