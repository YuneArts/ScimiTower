using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectImage : MonoBehaviour
{
    [SerializeField]
    public Image weaponSelectImage;
    private WeaponData weaponSelectData;

    void Awake()
    {
        weaponSelectData = DataHolder.Instance.mapWeaponSpawn;
        Debug.Log("Found Weapon Select Art");
    }

    public void ChangeWeaponSelectImage()
    {
        weaponSelectImage.sprite = weaponSelectData.art;
    }
}
