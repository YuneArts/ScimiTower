using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;

    public int attack;
    public int durability;

    public Sprite art;

    public WeaponElement element;
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
