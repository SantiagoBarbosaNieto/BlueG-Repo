using UnityEngine;

public class InventorySlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("Item named " + itemDropped.name + " was dropped on slot " + this.name);
    }

}