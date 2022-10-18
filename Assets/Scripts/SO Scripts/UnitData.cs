using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Unit")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public UnitElement uElement;
    public UnitAlignment uAlignment;
    public UnitWeaponResistance uResistBPS;
    public UnitWeaponWeakness uWeakBPS;

    public int uDamage;

    public int uMaxHP;
    public int uCurrentHP;
    public bool isBoss;

    public Sprite uSprite;
}

public enum UnitElement
{
    None,
    Fire,
    Water,
    Grass,
    Light,
    Dark
}

public enum UnitAlignment
{
    None,
    Light,
    Dark
}

public enum UnitWeaponResistance
{
    None,
    Bludgeon,
    Pierce,
    Slash
}

public enum UnitWeaponWeakness
{
    None,
    Bludgeon,
    Pierce,
    Slash
}