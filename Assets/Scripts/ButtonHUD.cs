using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHUD : MonoBehaviour
{
    public WeaponData weapon;

    public Text nameText;
    public Text damageText;
    public Text durabilityText;

    public Image weaponArt;

    void Start()
    {
        nameText.text = weapon.name;
        damageText.text = weapon.attack.ToString();
        durabilityText.text = weapon.durability.ToString();
        weaponArt.sprite = weapon.art;
    }
}
