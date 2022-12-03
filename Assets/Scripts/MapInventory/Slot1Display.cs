using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot1Display : MonoBehaviour
{
    public WeaponData slot1Weapon;
    public Image eleArt, aliArt;
    [SerializeField]
    private Sprite fire, water, grass, lightAli, dark;
    private Color eleColor = new Color(1, 1, 1, 1), aliColor = new Color(1, 1, 1, 1);

    void Start()
    {
        slot1Weapon = DataHolder.Instance.playerInventory.Container[0];

        SetWeaponElement(slot1Weapon.element);
        SetWeaponAlignment(slot1Weapon.alignment);
    }

    private void SetWeaponElement(WeaponElement eleCheck)
    {
        switch (slot1Weapon.element)
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
        switch (slot1Weapon.alignment)
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
