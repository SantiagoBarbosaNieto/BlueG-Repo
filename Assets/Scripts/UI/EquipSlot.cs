using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BG.Enums;
using System;

public class EquipSlot : I_Slot
{
    [SerializeField] private PlayerEquipment manager;
    [SerializeField] private EquipType equipSlotType;

    protected override void OnSomethingDropped(Transform itemDropped)
    {
        //Handle equipment change communication with player
        EquipableItem equippable = itemDropped.GetComponent<EquipableItem>();
        if(equippable == null)
        {
            Debug.LogError("Item dropped in equip slot is not equippable");
            return;
        }
        manager.Equip(equippable);
    }

    //Override extraChecks
    protected override bool ExtraChecksBeforeDrop(GameObject item)
    {
        EquipableItem equipable = item.GetComponent<EquipableItem>();
        if(equipable == null)
        {
            Debug.Log("You can't equip that!");
            return false;
        }

        if(equipable.EquippableType != equipSlotType) 
        {
            Debug.Log("It's not the right slot type!");
            return false;
        }
        
        if(item.GetComponent<EquipableItem>().parentToReturnTo.GetComponent<I_Slot>() is ShopSlot)
        {
            Debug.Log("You cannot steal! >:(");
            return false;
        }

        
        return true;

         
    }

    internal void Unequip()
    {
        manager.Unequip(equipSlotType);
    }
}
