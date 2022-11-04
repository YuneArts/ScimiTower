using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/AscensionInventory")]
public class AscensionModeInventory : ScriptableObject
{
    public List<AscensionModeActions> Container = new List<AscensionModeActions>();
}
