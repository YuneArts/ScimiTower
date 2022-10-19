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
    [SerializeField]
    private InventoryScript newGameInventory;
    [SerializeField]
    private UnitData startingEnemy;
    [SerializeField]
    private WeaponData startingWeapon;

    public UnitData playerHealthInfo;

    //Stats for the end game results screen.
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

    public void StartNewGame()
    {
        playerInventory.Container[0] = newGameInventory.Container[0];
        playerInventory.Container[1] = newGameInventory.Container[1];
        playerInventory.Container[2] = newGameInventory.Container[2];
        playerInventory.Container[3] = newGameInventory.Container[3];
        playerHealthInfo.uCurrentHP = playerHealthInfo.uMaxHP;
        currentIndex = 0;
        mapEnemySpawn = startingEnemy;
        mapWeaponSpawn = startingWeapon;
    }
}
