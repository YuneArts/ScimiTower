using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;
    public int currentIndex = 0;

    public UnitData mapEnemySpawn;
    public WeaponData mapWeaponSpawn;

    public InventoryScript playerInventory;

    public UnitData playerHealthInfo;

    public int weaponCountStat;
    public int enemyCountStat;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
