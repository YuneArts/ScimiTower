using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;

    public int attack;
    public int durability;
    public int maxDurability;

    public int healingValue;

    public Sprite art;

    public WeaponType weaponBPS;
    public WeaponElement element;
    public WeaponAlignment alignment;

    void OnEnable()
    {
        durability = maxDurability;
    }
}

public enum WeaponElement
{
    None,
    Fire,
    Water,
    Grass,
    Light,
    Dark
}

public enum WeaponType
{
    None,
    Bludgeon,
    Pierce,
    Slash
}

public enum WeaponAlignment
{
    None,
    Light,
    Dark
}
