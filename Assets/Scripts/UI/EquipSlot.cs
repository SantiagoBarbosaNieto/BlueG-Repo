using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BG.Enums;

public class EquipSlot : I_Slot
{
    [SerializeField] private PlayerEquipment manager;
    [SerializeField] private EquipType equipSlotType;

    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("Item named " + itemDropped.name + " dropped in equip slot");
        //Handle equipment change communication with player
        EquippableItem equippable = itemDropped.GetComponent<EquippableItem>();
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
        EquippableItem equipable = item.GetComponent<EquippableItem>();
        if(equipable == null) return false;

        if(equipable.EquippableType != equipSlotType) return false;

        
        return true;

         
    }

}
