using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string cName;

    public UnitData unitInfo;

    [SerializeField]
    private Element cElement;
    public int damage;
    
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    void Awake()
    {
        cName = unitInfo.unitName;
        cElement = unitInfo.uElement;
        damage = unitInfo.uDamage;

        maxHP = unitInfo.uMaxHP;
        currentHP = unitInfo.uCurrentHP;

        Debug.Log("Element = " + cElement);
    }
}
