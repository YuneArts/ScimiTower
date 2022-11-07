using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AscensionDurability : MonoBehaviour
{
    public AscensionModeActions baseAttack;

    public TextMeshProUGUI currentAttackText, sharedDurabilityText;

    void Update()
    {
        SetAttackText();
        SetDurabilityText();
    }

    private void SetAttackText()
    {
        if (baseAttack.durabilityValue == 0 && baseAttack.attackValue > 0)
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
        if (baseAttack.defaultDurabilityValue > 0)
        {
            sharedDurabilityText.text = baseAttack.durabilityValue.ToString();
        }
    }
}