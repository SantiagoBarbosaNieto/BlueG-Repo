using UnityEngine;

public class ShopSlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("Item named " + itemDropped.name + " was dropped on slot " + this.name);
    }

    protected override bool ExtraChecksBeforeDrop(GameObject item)
    {
        
        
        if(item.GetComponent<EquipableItem>().parentToReturnTo.GetComponent<I_Slot>() is InventorySlot or EquipSlot)
        {
            Debug.Log("Hmm maybe do not give thingsaway for free :)");
            return false;
        }
        return true;
    }

}
