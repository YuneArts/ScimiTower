using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Action")]
public class AscensionModeActions : ScriptableObject
{
    public string actionName;

    public int attackValue;
    public int defaultAttackValue;

    public int durabilityValue;
    public int defaultDurabilityValue;

    public int blockValue;
    public int defaultBlockValue;

    public int healValue;
    public int defaultHealValue;

    public int damageBoost;
    public int defaultDamageBoost;

    public Sprite ascSprite;

    void OnEnable()
    {
        durabilityValue = defaultDurabilityValue;
    }
}
