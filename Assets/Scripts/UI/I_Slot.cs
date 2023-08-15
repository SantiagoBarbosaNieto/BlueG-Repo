using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class I_Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(!CanDropItem(eventData.pointerDrag)) return;

        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();
        item.SetParentToReturn(transform);
        OnSomethingDropped(transform);
    }

    public bool CanDropItem(GameObject itemDropped)
    {
        if(itemDropped == null) return false;

        DraggableItem item = itemDropped.GetComponent<DraggableItem>();
        if(item == null) return false;

        for(int i = 0; i < transform.childCount; i++)
        {
            DraggableItem childItem = transform.GetChild(i).GetComponent<DraggableItem>();
            if(childItem != null) return false;
        }
        
        return true;
    }

    protected abstract void OnSomethingDropped(Transform itemDropped);

}
