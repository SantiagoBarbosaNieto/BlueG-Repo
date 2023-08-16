using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField]
    GameObject playerInventory = null;
    public int coins {get;private set;} = 0;

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
    }

    public void BuyItem(EquipableItem item)
    {
        SpendCoins(item.price);
        playerInventory.GetComponent<InventoryManager>().AddItem(item);
        item.PlayerOwned = true;
    }

    public bool CanAfford(int amount)
    {
        return coins >= amount;
    }
}
