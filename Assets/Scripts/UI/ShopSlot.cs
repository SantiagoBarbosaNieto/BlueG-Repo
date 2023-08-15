using UnityEngine;

public class ShopSlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("Item named " + itemDropped.name + " was dropped on slot " + this.name);
    }

}
