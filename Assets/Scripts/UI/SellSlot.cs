using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSlot : I_Slot
{
    [Range(0,1)]
    [SerializeField] float sellPercentage;
    [SerializeField] InventoryManager storeInventory;
    PlayerCoins playerCoins;

    void Start()
    {
        playerCoins = FindObjectOfType<PlayerCoins>();
    }
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        EquipableItem item = itemDropped.GetComponent<EquipableItem>();
        playerCoins.AddCoins(Mathf.CeilToInt(sellPercentage*item.price));
        
        storeInventory.GetComponent<InventoryManager>().AddItem(item);
        item.PlayerOwned = false;
    }

    protected override bool ExtraChecksBeforeDrop(GameObject item)
    {
        if(!item.GetComponent<EquipableItem>().PlayerOwned)
        {   
            Debug.Log("You don't own that! :s");
            return false;
        }
        if(!storeInventory.CheckSpace())
        {
            Debug.Log("Store is full!");
            return false;
        }
        
        return true;
    }
}
