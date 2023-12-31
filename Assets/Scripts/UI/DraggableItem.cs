using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo {get; private set;} = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragBegan();
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(GetComponentInParent<Canvas>().transform);
        //Turn off raycast detection
        this.GetComponent<Image>().raycastTarget = false;
    }
    public virtual void DragBegan(){}

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.position = transform.parent.position;
        this.GetComponent<Image>().raycastTarget = true;
    }
    public void ChangeParent(Transform newParent)
    {
        parentToReturnTo = newParent;
        transform.SetParent(parentToReturnTo);
        transform.position = parentToReturnTo.position;
    }

    public void SetParentToReturn(Transform parent)
    {
        parentToReturnTo = parent;
        transform.SetAsLastSibling();
    }

}
