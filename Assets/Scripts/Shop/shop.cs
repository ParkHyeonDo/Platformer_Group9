using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour , IInteractable
{
    public ItemData item;
    public ShopInventory shopinventory;
    public int index;
    public bool equipped;
    public int quantity;


    public void Interact() 
    {
        shopinventory.gameObject.SetActive(true);
    }
}
