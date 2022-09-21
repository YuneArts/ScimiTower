using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData unit;

    public string cName;
  
    public int cDamage;
    
    public int cMaxHP;
    public int cCurrentHP;

    void Awake()
    {
        cName = unit.unitName;
        cDamage = unit.damage;
        cMaxHP = unit.maxHP;
        cCurrentHP = unit.currentHP;
    }

    public bool TakeDamage(int dmg)
    {
        cCurrentHP -= dmg;

        if (cCurrentHP <= 0)
            return true;
        else
            return false;
    }
}
