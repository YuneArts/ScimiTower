using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AscensionDurability : MonoBehaviour
{
    public AscensionModeActions baseAttack;
    [SerializeField]
    private BattleSystem batSys;

    public TextMeshProUGUI currentAttackText, sharedDurabilityText, healUsesText;

    void Update()
    {
        SetAttackText();
        SetDurabilityText();
        SetHealingUses();
    }

    private void SetAttackText()
    {
        if (baseAttack.durabilityValue <= 0 && baseAttack.attackValue > 0)
        {
            currentAttackText.text = "Broken";
        }
        else if (baseAttack.durabilityValue > 0 && baseAttack.attackValue > 0)
        {
            currentAttackText.text = baseAttack.attackValue.ToString();
        }
    }

    private void SetDurabilityText()
    {
        if (baseAttack.durabilityValue > 0)
        {
            sharedDurabilityText.text = baseAttack.durabilityValue.ToString();
        }
        else if (baseAttack.durabilityValue <= 0)
        {
            sharedDurabilityText.text = "0";
        }
    }

    private void SetHealingUses()
    {
        healUsesText.text = batSys.healUses.ToString();
    }
}
