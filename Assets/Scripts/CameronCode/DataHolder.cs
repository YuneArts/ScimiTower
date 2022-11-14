using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance;
    public int currentIndex = 0;
    public int tutorialIndex;

    public UnitData mapEnemySpawn;
    public WeaponData mapWeaponSpawn;

    public InventoryScript playerInventory;
    public AscensionModeInventory ascInventory;
    [SerializeField]
    private InventoryScript newDescensionInventory;
    [SerializeField]
    private AscensionModeActions ascAttack, ascBlock, ascRest;
    [SerializeField]
    private AscensionUpgrade startUp1, startUp2, startUp3;
    [SerializeField]
    private UnitData startingEnemy;
    [SerializeField]
    private WeaponData startingWeapon, steelSword;

    public bool descensionMode;
    public bool ascensionMode;
    public bool tutorialEnabled;

    public UnitData playerHealthInfo;

    //Stats for the end game results screen.
    public int weaponCountStat;
    public int enemyCountStat;

    public AscensionUpgrade mapUpgrade1, mapUpgrade2, mapUpgrade3;

    public GameObject positionManager;
    
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
        
        if(tutorialEnabled == true)
        {
            tutorialIndex = 0;
        }
    }

    public void StartAscensionMode()
    {
        ascAttack.attackValue = ascAttack.defaultAttackValue;
        ascAttack.durabilityValue = ascAttack.defaultDurabilityValue;
        ascBlock.blockValue = ascBlock.defaultBlockValue;
        ascRest.healValue = ascRest.defaultHealValue;

        mapEnemySpawn = startingEnemy;
        mapUpgrade1 = startUp1;
        mapUpgrade2 = startUp2;
        mapUpgrade3 = startUp3;
        
        playerHealthInfo.uCurrentHP = playerHealthInfo.uMaxHP;
        currentIndex = 0;
        ascensionMode = true;
        descensionMode = false;
    }
}
