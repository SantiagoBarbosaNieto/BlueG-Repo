using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : I_Slot
{
    protected override void OnSomethingDropped(Transform itemDropped)
    {
        Debug.Log("EquipSlot: OnSomethingDropped  (" + itemDropped.name + ") on (" + this.name + ")");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
