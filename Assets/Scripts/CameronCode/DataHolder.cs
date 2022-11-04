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
    public AscensionModeInventory ascInventory;
    [SerializeField]
    private InventoryScript newDescensionInventory;
    [SerializeField]
    private AscensionModeActions ascAttack, ascBlock, ascRest;
    [SerializeField]
    private UnitData startingEnemy;
    [SerializeField]
    private WeaponData startingWeapon, steelSword;

    public bool descensionMode;
    public bool ascensionMode;

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

    public void StartDescensionMode()
    {
        playerInventory.Container[0] = Instantiate(steelSword);
        playerInventory.Container[1] = newDescensionInventory.Container[1];
        playerInventory.Container[2] = newDescensionInventory.Container[2];
        playerInventory.Container[3] = newDescensionInventory.Container[3];
        playerHealthInfo.uCurrentHP = playerHealthInfo.uMaxHP;
        currentIndex = 0;
        mapEnemySpawn = startingEnemy;
        mapWeaponSpawn = startingWeapon;

        ascensionMode = false;
        descensionMode = true;
    }

    public void StartAscensionMode()
    {
        ascAttack.attackValue = ascAttack.defaultAttackValue;
        ascAttack.durabilityValue = ascAttack.defaultDurabilityValue;
        ascBlock.blockValue = ascBlock.defaultBlockValue;
        ascRest.healValue = ascRest.defaultHealValue;

        mapEnemySpawn = startingEnemy;
        
        playerHealthInfo.uCurrentHP = playerHealthInfo.uMaxHP;
        currentIndex = 0;
        ascensionMode = true;
        descensionMode = false;
    }
}
