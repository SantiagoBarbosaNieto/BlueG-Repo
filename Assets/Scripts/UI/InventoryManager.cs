using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public void AddItem(EquipableItem item)
    {
        for(int i = transform.childCount-1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponentInChildren<EquipableItem>() == null)
            {
                item.SetParentToReturn(child.transform);    
                item.ChangeParent(child.transform);
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
