using UnityEngine;

public class InventorySlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        
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
