using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySlot : I_Slot
{
    
    PlayerCoins playerCoins;

    [SerializeField]
    InventoryManager playerInventoryManager;
    void Awake()
    {
        playerCoins = FindObjectOfType<PlayerCoins>();
    }

    protected override void OnSomethingDropped(Transform itemDropped)
    {
        EquipableItem item = itemDropped.GetComponent<EquipableItem>();
        if(item == null) return;
        playerCoins.BuyItem(item);
        item.GetComponent<Image>().raycastTarget = true;
    }

    protected override bool ExtraChecksBeforeDrop(GameObject item)
    {
        if(!playerCoins.CanAfford(item.GetComponent<EquipableItem>().price))
        {
            Debug.Log("You can't affor that!\n Price: " + item.GetComponent<EquipableItem>().price + "\n Coins: " + playerCoins.coins);
            return false;
        }

        if(!playerInventoryManager.CheckSpace())
        {
            Debug.Log("There is not enough space in inventory!");
            return false;
        }
        if(item.GetComponent<EquipableItem>().parentToReturnTo.GetComponent<I_Slot>() is EquipSlot or InventorySlot)
        {
            Debug.Log("You cannot buy something you own!");
            return false;
        }

        return  true;
    }
}
