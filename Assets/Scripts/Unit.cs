using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string cName;

    public UnitData unitInfo;

    public UnitElement cElement;
    public int damage;
    
    public int maxHP;
    public int currentHP;

    public Sprite cSprite;
    public SpriteRenderer characterSprite;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        //unitInfo.uCurrentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int healAmount)
    {
        currentHP += healAmount;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void SetPlayerHP()
    {
        unitInfo.uCurrentHP = currentHP;
        DataHolder.Instance.playerHealthInfo.uCurrentHP = currentHP;
    }

    void Start()
    {
        cName = unitInfo.unitName;
        cElement = unitInfo.uElement;
        damage = unitInfo.uDamage;

        maxHP = unitInfo.uMaxHP;
        currentHP = unitInfo.uCurrentHP;

        cSprite = unitInfo.uSprite;

        Debug.Log("Element = " + cElement);
    }

    public void UpdateEnemyInfo()
    {
        cName = unitInfo.unitName;
        cElement = unitInfo.uElement;
        damage = unitInfo.uDamage;

        maxHP = unitInfo.uMaxHP;
        currentHP = unitInfo.uCurrentHP;

        cSprite = unitInfo.uSprite;

        Debug.Log("Element = " + cElement);
    }

    public void UpdateEnemySprite()
    {
        characterSprite.sprite = cSprite;
    }
}
