using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public void AddItem(EquipableItem item)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponentInChildren<EquipableItem>() == null)
            {
                item.SetParentToReturn(child.transform);    
                item.ChangeParent(child.transform);

                //Reset transform to center of parent
                item.transform.localScale = Vector3.one;
                //Make the position of the normal transform 0
                item.transform.localPosition = Vector3.zero;
                //Make the position of the rect transform 0
                item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                return;

            }
        }
    }

    public bool CheckSpace()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponentInChildren<EquipableItem>() == null)
            {
                return true;
            }
        }
        return false;
    }
}
