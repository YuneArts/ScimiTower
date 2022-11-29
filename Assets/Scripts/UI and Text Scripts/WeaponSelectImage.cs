using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectImage : MonoBehaviour
{
    [SerializeField]
    public Image weaponSelectImage, weaponSelectElement, weaponSelectAlignment;
    private WeaponData weaponSelectData;
    [SerializeField]
    private Sprite fire, water, grass, lightAli, dark;
    private Color selectEleColor = new Color(1, 1, 1, 1), selectAliColor = new Color(1, 1, 1, 1);

    void Awake()
    {
        weaponSelectData = DataHolder.Instance.mapWeaponSpawn;
        Debug.Log("Found Weapon Select Art");
    }

    public void ChangeWeaponSelectImage()
    {
        weaponSelectImage.sprite = weaponSelectData.art;
        SetWeaponElement(weaponSelectData.element);
        SetWeaponAlignment(weaponSelectData.alignment);
    }

    private void SetWeaponElement(WeaponElement selectEleCheck)
    {
        switch (weaponSelectData.element)
        {
            case WeaponElement.Fire:
                selectEleColor.a = 1;
                weaponSelectElement.color = selectEleColor;
                weaponSelectElement.sprite = fire;
                break;
            case WeaponElement.Water:
                selectEleColor.a = 1;
                weaponSelectElement.color = selectEleColor;
                weaponSelectElement.sprite = water;
                break;
            case WeaponElement.Grass:
                selectEleColor.a = 1;
                weaponSelectElement.color = selectEleColor;
                weaponSelectElement.sprite = grass;
                break;
            case WeaponElement.None:
                selectEleColor.a = 0;
                weaponSelectElement.color = selectEleColor;
                break;
            default:
                selectEleColor.a = 0;
                weaponSelectElement.color = selectEleColor;
                return;
        }
    }

    private void SetWeaponAlignment(WeaponAlignment selectAliCheck)
    {
        switch (weaponSelectData.alignment)
        {
            case WeaponAlignment.Light:
                selectAliColor.a = 1;
                weaponSelectAlignment.color = selectAliColor;
                weaponSelectAlignment.sprite = lightAli;
                break;
            case WeaponAlignment.Dark:
                selectAliColor.a = 1;
                weaponSelectAlignment.color = selectAliColor;
                weaponSelectAlignment.sprite = dark;
                break;
            case WeaponAlignment.None:
                selectAliColor.a = 0;
                weaponSelectAlignment.color = selectAliColor;
                break;
            default:
                selectAliColor.a = 0;
                weaponSelectAlignment.color = selectAliColor;
                return;
        }
    }
}
