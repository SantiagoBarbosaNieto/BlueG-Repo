using UnityEngine;

public class InventorySlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("Item named " + itemDropped.name + " was dropped on slot " + this.name);
    }

    protected override bool ExtraChecksBeforeDrop(GameObject item)
    {
        if(item.GetComponent<EquipableItem>().parentToReturnTo.GetComponent<I_Slot>() is ShopSlot)
        {
            Debug.Log("You cannot steal! >:(");
            return false;
        }
        return true;
    }

}
