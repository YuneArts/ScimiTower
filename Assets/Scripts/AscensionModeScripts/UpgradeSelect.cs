using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Map Spawn/Upgrade Pool")]
public class UpgradeSelect : ScriptableObject
{
    public List<AscensionUpgrade> Container = new List<AscensionUpgrade>();
}
