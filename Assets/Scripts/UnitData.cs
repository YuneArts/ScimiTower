using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Unit")]
public class UnitData : ScriptableObject
{
    public string unitName;

    public int uDamage;

    public int uMaxHP;
    public int uCurrentHP;
}
