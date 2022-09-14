using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    public string name;

    public int attack;
    public int durability;

    public Sprite art;
}
