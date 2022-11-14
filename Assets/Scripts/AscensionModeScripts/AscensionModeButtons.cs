using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionModeButtons : MonoBehaviour
{
    [SerializeField]
    private AscensionModeInventory ascensionContainers;

    [SerializeField]
    private BattleSystem batSys;

    public int ascensionDamage;
    public int ascensionDurability;
    public int ascensionHealing;
    public int ascensionBlock;
    public int ascensionBoost;

    public bool usedAttack, usedBlock, usedRest;

    public void WeakAttack()
    {
        if (DataHolder.Instance.ascensionMode == true)
        {
            if (ascensionContainers.Container[0].durabilityValue > 0 && batSys.canAttack == true)
            {
                usedAttack = true;
                ascensionDamage = ascensionContainers.Container[0].attackValue;
                ascensionContainers.Container[0].durabilityValue -= 1;
                batSys.OnAttackButton();
                batSys.canAttack = false;
            }
        }
    }

    public void StrongAttack()
    {
        if (DataHolder.Instance.ascensionMode == true)
        {
            if (ascensionContainers.Container[1].durabilityValue > 0 && batSys.canAttack == true)
            {
                usedAttack = true;
                ascensionDamage = (int)(ascensionContainers.Container[1].attackValue * 1.5);
                ascensionContainers.Container[1].durabilityValue -= 2;
                batSys.OnAttackButton();
                batSys.canAttack = false;
            }
        }
    }

    public void Block()
    {
        if (DataHolder.Instance.ascensionMode == true)
        {
            if (batSys.canAttack == true)
            {
                usedBlock = true;
                ascensionBlock = ascensionContainers.Container[2].blockValue;
                batSys.OnAttackButton();
                batSys.canAttack = false;
            }
        }
    }

    public void Rest()
    {
        if (DataHolder.Instance.ascensionMode == true)
        {
            if (batSys.canAttack == true && batSys.healUses > 0)
            {
                usedRest = true;
                ascensionHealing = ascensionContainers.Container[3].healValue;
                ascensionBoost = ascensionContainers.Container[3].damageBoost;
                batSys.OnAttackButton();
                batSys.canAttack = false;
            }
        }
    }
}
