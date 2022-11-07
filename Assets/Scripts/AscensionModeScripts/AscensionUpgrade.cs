using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade")]
public class AscensionUpgrade : ScriptableObject
{
    public string upName;

    public int upDamage;
    public int upBlock;
    public int upHeal;
    public int upDurability;
    public Sprite upSprite;

    public string description;
}
