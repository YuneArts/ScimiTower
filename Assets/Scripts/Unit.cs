using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string cName;

    public UnitData unitInfo;

    public UnitElement cElement;
    public UnitAlignment cAlignment;
    public UnitWeaponResistance cResistBPS;
    public UnitWeaponWeakness cWeakBPS;
    public int damage;
    
    public int maxHP;
    public int currentHP;
    public bool midBossUnit;
    public bool finalBossUnit;

    public Sprite cSprite;
    public SpriteRenderer characterSprite;

    public Animator unitAnimator;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        //unitInfo.uCurrentHP -= dmg;

        if (currentHP <= 0)
        {
            currentHP = 0;
            return true;
        }
        else
        {
            return false;
        }
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
        cAlignment = unitInfo.uAlignment;
        cResistBPS = unitInfo.uResistBPS;
        cWeakBPS = unitInfo.uWeakBPS;
        damage = unitInfo.uDamage;

        maxHP = unitInfo.uMaxHP;
        currentHP = unitInfo.uCurrentHP;

        cSprite = unitInfo.uSprite;

        midBossUnit = unitInfo.isMidBoss;
        finalBossUnit = unitInfo.isFinalBoss;

        Debug.Log("Element = " + cElement);
    }

    public void UpdateEnemySprite()
    {
        characterSprite.sprite = cSprite;
    }
}
