using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class I_Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(!CanDropItem(eventData.pointerDrag)) return;

        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();

        DraggableItem oldItem = transform.GetComponentInChildren<DraggableItem>();
        if(oldItem != null) 
        {
            oldItem.ChangeParent(item.parentToReturnTo);
        }
        item.SetParentToReturn(transform);

        //Search price tag in children
        PriceTag priceTag = item.GetComponentInChildren<PriceTag>();
        if(priceTag != null)
        {
            priceTag.UpdatePrice();
        }


        OnSomethingDropped(item.transform);
    }

    public bool CanDropItem(GameObject itemDropped)
    {
        if(itemDropped == null) return false;

        DraggableItem item = itemDropped.GetComponent<DraggableItem>();
        if(item == null) return false;
        
        return ExtraChecksBeforeDrop(itemDropped); 
    }



    protected virtual bool ExtraChecksBeforeDrop(GameObject item)
    {
        return true;
    }

    protected abstract void OnSomethingDropped(Transform itemDropped);

}
