using System.Collections.Generic;
using UnityEngine;
using BG.Enums;

public class EquipableItem : DraggableItem
{
    [SerializeField] public int price = 1;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private EquipType equippableType;

    public bool PlayerOwned = false;

    public List<Sprite> Sprites {get => sprites; private set => sprites = value;}
    public EquipType EquippableType {get => equippableType; private set => equippableType = value;}

    public override void DragBegan()
    {
        EquipSlot slot = transform.GetComponentInParent<EquipSlot>();
        if(slot == null) return;
        slot.Unequip();

    }

    public bool CanAfford()
    {
        PlayerCoins playerCoins = FindObjectOfType<PlayerCoins>();
        if(playerCoins == null) return false;
        return playerCoins.CanAfford(price);
    }
}