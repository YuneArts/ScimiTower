using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Unit")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public UnitElement uElement;

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
