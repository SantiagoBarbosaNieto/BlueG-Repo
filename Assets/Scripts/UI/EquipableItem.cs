using System.Collections.Generic;
using UnityEngine;
using BG.Enums;

public class EquippableItem : DraggableItem
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private EquipType equippableType;

    public List<Sprite> Sprites {get => sprites; private set => sprites = value;}
    public EquipType EquippableType {get => equippableType; private set => equippableType = value;}

}