using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;
    public int currentIndex = 0; 

    public UnitData mapEnemySpawn;
    public InventoryScript playerInventory;
    public WeaponData mapWeaponSpawn;
    
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
