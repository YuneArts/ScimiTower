using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot2Display : MonoBehaviour
{
    public WeaponData slot2Weapon;
    public Image eleArt, aliArt;
    [SerializeField]
    private Sprite fire, water, grass, lightAli, dark;
    private Color eleColor = new Color(1, 1, 1, 1), aliColor = new Color(1, 1, 1, 1);

    void Start()
    {
        slot2Weapon = DataHolder.Instance.playerInventory.Container[1];

        SetWeaponElement(slot2Weapon.element);
        SetWeaponAlignment(slot2Weapon.alignment);
    }

    private void SetWeaponElement(WeaponElement eleCheck)
    {
        switch (slot2Weapon.element)
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
        switch (slot2Weapon.alignment)
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
