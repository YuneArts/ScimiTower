using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Selection", menuName = "Enemy Spawn/Enemy Pool")]
public class EnemySelect : ScriptableObject
{
    public List<UnitData> Container = new List<UnitData>();
}
