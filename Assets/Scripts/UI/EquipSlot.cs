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
        Debug.Log("Item named " + itemDropped.name + " dropped in equip slot");
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
        if(equipable == null) return false;

        if(equipable.EquippableType != equipSlotType) return false;

        
        return true;

         
    }

    internal void Unequip()
    {
        manager.Unequip(equipSlotType);
    }
}
