using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public WeaponData weapon;

    public Text nameText;
    public Text damageText;
    public Text durabilityText;

    public Image weaponArt;
    public Image eleArt, aliArt;
    [SerializeField]
    private Sprite fire, water, grass, lightAli, dark;
    private Color eleColor = new Color(1, 1, 1, 1), aliColor = new Color(1, 1, 1, 1);
    void Start()
    {
        nameText.text = weapon.weaponName;
        damageText.text = weapon.attack.ToString();
        durabilityText.text = weapon.durability.ToString();
        weaponArt.sprite = weapon.art;
        SetWeaponAlignment(weapon.alignment);
        SetWeaponElement(weapon.element);
    }

    private void SetWeaponElement(WeaponElement eleCheck)
    {
        switch (weapon.element)
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
        switch (weapon.alignment)
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

    void Update()
    {
        durabilityText.text = weapon.durability.ToString() + "/" + weapon.maxDurability.ToString();
    }
}
