using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot4Display : MonoBehaviour
{
    public WeaponData slot4Weapon;
    public Image eleArt, aliArt;
    [SerializeField]
    private Sprite fire, water, grass, lightAli, dark;
    private Color eleColor = new Color(1, 1, 1, 1), aliColor = new Color(1, 1, 1, 1);

    void Start()
    {
        slot4Weapon = DataHolder.Instance.playerInventory.Container[3];

        SetWeaponElement(slot4Weapon.element);
        SetWeaponAlignment(slot4Weapon.alignment);
    }

    private void SetWeaponElement(WeaponElement eleCheck)
    {
        switch (slot4Weapon.element)
        {
            case WeaponElement.Fire:
                eleColor.a = 1;
                eleArt.color = eleColor;
                eleArt.sprite = fire;
                break;
            case WeaponElement.Water:
                eleColor.a = 1;
                eleArt.color = eleColor;
                eleArt.sprite = water;
                break;
            case WeaponElement.Grass:
                eleColor.a = 1;
                eleArt.color = eleColor;
                eleArt.sprite = grass;
                break;
            case WeaponElement.None:
                eleColor.a = 0;
                eleArt.color = eleColor;
                break;
            default:
                eleColor.a = 0;
                eleArt.color = eleColor;
                return;
        }
    }

    private void SetWeaponAlignment(WeaponAlignment aliCheck)
    {
        switch (slot4Weapon.alignment)
        {
            case WeaponAlignment.Light:
                aliColor.a = 1;
                aliArt.color = aliColor;
                aliArt.sprite = lightAli;
                break;
            case WeaponAlignment.Dark:
                aliColor.a = 1;
                aliArt.color = aliColor;
                aliArt.sprite = dark;
                break;
            case WeaponAlignment.None:
                aliColor.a = 0;
                aliArt.color = aliColor;
                break;
            default:
                aliColor.a = 0;
                aliArt.color = aliColor;
                return;
        }
    }
}
