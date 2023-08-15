using System.Collections.Generic;
using UnityEngine;
using BG.Enums;

public class PlayerEquipment: MonoBehaviour
{     
    [Header("Equipment Objects")]
    [SerializeField] GameObject headEquip;
    [SerializeField] GameObject torsoEquip;
    [SerializeField] GameObject pelvisEquip;
    [SerializeField] GameObject leftLegEquip;
    [SerializeField] GameObject leftBootEquip;
    [SerializeField] GameObject rightLegEquip;
    [SerializeField] GameObject rightBootEquip;
    [SerializeField] GameObject leftShoulderEquip;
    [SerializeField] GameObject leftElbowEquip;
    [SerializeField] GameObject leftHandEquip;
    [SerializeField] GameObject rightHandEquip;
    [SerializeField] GameObject rightElbowEquip;
    [SerializeField] GameObject rightShoulderEquip;
    [SerializeField] GameObject leftWeaponEquip;
    [SerializeField] GameObject rightWeaponEquip;

    [Header("Default Sprites")]
    [SerializeField] Sprite headDefault;
    [SerializeField] Sprite torsoDefault;
    [SerializeField] Sprite pelvisDefault;
    [SerializeField] Sprite leftLegDefault;
    [SerializeField] Sprite leftBootDefault;
    [SerializeField] Sprite rightLegDefault;
    [SerializeField] Sprite rightBootDefault;
    [SerializeField] Sprite leftShoulderDefault;
    [SerializeField] Sprite leftElbowDefault;
    [SerializeField] Sprite leftHandDefault;
    [SerializeField] Sprite rightHandDefault;
    [SerializeField] Sprite rightElbowDefault;
    [SerializeField] Sprite rightShoulderDefault;
    [SerializeField] Sprite leftWeaponDefault;
    [SerializeField] Sprite rightWeaponDefault;

    public void EquipHead(Sprite head)
    {
        headEquip.GetComponent<SpriteRenderer>().sprite = head;
    }

    public void EquipCore(List<Sprite> sprites)
    {
        if (sprites.Count != 2)
        {
            Debug.LogError("Core must have 2 sprites");
            return;
        }
        torsoEquip.GetComponent<SpriteRenderer>().sprite = sprites[0];
        pelvisEquip.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    public void EquipLegs(List<Sprite> sprites) //Not the best way, but it works with the time I have
    {
        if(sprites.Count != 4)
        {
            Debug.LogError("Legs must have 4 sprites");
            return;
        }
        leftLegEquip.GetComponent<SpriteRenderer>().sprite = sprites[0];
        leftBootEquip.GetComponent<SpriteRenderer>().sprite = sprites[1];
        rightLegEquip.GetComponent<SpriteRenderer>().sprite = sprites[2];
        rightBootEquip.GetComponent<SpriteRenderer>().sprite = sprites[3];

    }

    public void EquipArms(List<Sprite> sprites)
    {
        if (sprites.Count != 6)
        {
            Debug.LogError("Arms must have 6 sprites");
            return;
        }
        leftShoulderEquip.GetComponent<SpriteRenderer>().sprite = sprites[0];
        leftElbowEquip.GetComponent<SpriteRenderer>().sprite = sprites[1];
        leftHandEquip.GetComponent<SpriteRenderer>().sprite = sprites[2];
        rightHandEquip.GetComponent<SpriteRenderer>().sprite = sprites[3];
        rightElbowEquip.GetComponent<SpriteRenderer>().sprite = sprites[4];
        rightShoulderEquip.GetComponent<SpriteRenderer>().sprite = sprites[5];
    }

    public void EquipWeapons(List<Sprite> sprites)
    {
        if (sprites.Count == 0)
        {
            Debug.LogError("Weapons must have atl least 1 sprite");
            return;
        }
        rightWeaponEquip.GetComponent<SpriteRenderer>().sprite = sprites[0];
        if(sprites.Count == 1) return;
        leftWeaponEquip.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    public void Equip(EquippableItem item)
    {
        switch(item.EquippableType)
        {
            case EquipType.Head:
                EquipHead(item.Sprites[0]);
                break;
            case EquipType.Core:
                EquipCore(item.Sprites);
                break;
            case EquipType.Legs:
                EquipLegs(item.Sprites);
                break;
            case EquipType.Arms:
                EquipArms(item.Sprites);
                break;
            case EquipType.Weapons:
                EquipWeapons(item.Sprites);
                break;
            default:
                Debug.Log("No recognizable equip type found");
                break;
            
        }
    }
}