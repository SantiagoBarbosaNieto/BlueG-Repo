using System.Collections.Generic;
using UnityEngine;
using BG.Enums;

public class EquipableItem : DraggableItem
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private EquipType equippableType;

    public List<Sprite> Sprites {get => sprites; private set => sprites = value;}
    public EquipType EquippableType {get => equippableType; private set => equippableType = value;}

    public override void DragBegan()
    {
        EquipSlot slot = transform.GetComponentInParent<EquipSlot>();
        Debug.Log("Drag begun + name of parent: " + transform.parent.name);
        if(slot == null) return;
        Debug.Log("Equip slot found");
        slot.Unequip();

    }
}