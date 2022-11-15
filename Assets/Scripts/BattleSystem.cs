using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private BattleState state;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    [SerializeField]
    private Text battleText;

    [SerializeField]
    private GameObject playerPrefab, enemyPrefab;
    [SerializeField]
    private Transform playerBattleStation, enemyBattleStation;
    [SerializeField]
    private GameObject bedroom, hallway1, hallway2, bottomFloor, towerTop;

    Unit playerUnit;
    Unit enemyUnit;

    public bool canAttack;
    [SerializeField]
    private bool midBoss, finalBoss, enemyAbsorb;

    public GameObject weaponSelect;
    public InventoryScript inventory;
    public List<WeaponDisplay> weaponDisplay;
    public ButtonScript booton;
    public AscensionModeButtons ascensionBattle;
    public WeaponSelectImage weaponSelectArt;
    public AscensionUpgradeImage upgradeArt;

    private int finalDamage;
    private int enemyCalc;
    [SerializeField]
    private float elementSuperEffective, elementNotEffective, alignmentSuperEffective, alignmentNotEffective, bpsSuperEffective, bpsNotEffective;
    [SerializeField]
    private int elementAbsorbBuff, postBossHeal;
    private float neutralDamage = 1f;
    private float elementMultiplier, alignmentMultiplier, bpsMultiplier;

    [SerializeField]
    private Transform playerDamageText, enemyDamageText, playerHealText, enemyHealText;
    [SerializeField]
    private GameObject damageTextPrefab, healTextPrefab;
    [SerializeField]
    private ResultsScreen winloseScreen;
    [SerializeField]
    private GameObject ascUpgradeSelect;

    public int blockDamageReduc;
    public int tempRestBoost;
    public int healUses;

    [SerializeField]
    private TutorialManager tutorialManager;

    public GameObject attacks;

    void Start()
    {
        canAttack = false;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        blockDamageReduc = 0;
        tempRestBoost = 0;
        healUses = 2;
    }

    private void Update()
    {
        if (DataHolder.Instance.descensionMode == true)
        {
            if (inventory.Container.Count == 1)
            {
                weaponDisplay[0].weapon = inventory.Container[0];
            }
            else if (inventory.Container.Count == 2)
            {
                weaponDisplay[0].weapon = inventory.Container[0];
                weaponDisplay[1].weapon = inventory.Container[1];
            }
            else if (inventory.Container.Count == 3)
            {
                weaponDisplay[0].weapon = inventory.Container[0];
                weaponDisplay[1].weapon = inventory.Container[1];
                weaponDisplay[2].weapon = inventory.Container[2];
            }
            else if (inventory.Container.Count == 4)
            {
                weaponDisplay[0].weapon = inventory.Container[0];
                weaponDisplay[1].weapon = inventory.Container[1];
                weaponDisplay[2].weapon = inventory.Container[2];
                weaponDisplay[3].weapon = inventory.Container[3];
            }
        }
    }

    IEnumerator SetupBattle()
    {
        //GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerPrefab.GetComponent<Unit>();
        //GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyPrefab.GetComponent<Unit>();

        playerUnit.currentHP = DataHolder.Instance.playerHealthInfo.uCurrentHP;

        playerHUD.SetHP(playerUnit.currentHP);

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.unitInfo = DataHolder.Instance.mapEnemySpawn;

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemyInfo();

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemySprite();
        //playerUnit.UpdateEnemySprite();

        if (enemyUnit.finalBossUnit == true)
        {
            finalBoss = true;
        }
        else if (enemyUnit.midBossUnit == true)
        {
            midBoss = true;
        }
        else
        {
            midBoss = false;
            finalBoss = false;
        }

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        //yield return new WaitForSeconds(0.01f);

        ChangeBackground();

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        canAttack = true;
    }

    public IEnumerator PlayerAttack()
    {
        if (state == BattleState.PLAYERTURN)
        {
            if (DataHolder.Instance.descensionMode == true)
            {
                //Calculate damage past resistances and weaknesses
                StartCoroutine(CalculateDamage(booton.wDamage, booton.wElement, booton.wAlignment, booton.wType));
                //Start healing if weapon action has healing
                if (booton.wHealing > 0)
                {
                    playerUnit.Heal(booton.wHealing);
                    HealText.Create(healTextPrefab, playerHealText, booton.wHealing);
                }

                yield return new WaitForSeconds(0.05f);

                playerUnit.unitAnimator.SetTrigger("Attack");

                yield return new WaitForSeconds(0.1f);

                enemyUnit.unitAnimator.SetTrigger("Hit");

                //Damage the Enemy
                bool isDead = enemyUnit.TakeDamage(finalDamage);
                playerHUD.SetHP(playerUnit.currentHP);
                enemyHUD.SetHP(enemyUnit.currentHP);
                //Creates the damage numbers next to the enemy.
                DamageText.Create(damageTextPrefab, enemyDamageText, finalDamage);
                //If elemental typing match up, enemy drains attack and gains a damage boost from it.
                if (enemyAbsorb)
                {
                    ElementBoost(elementAbsorbBuff);
                }

                yield return new WaitForSeconds(0.01f);

                enemyAbsorb = false;

                if (isDead)
                {
                    enemyUnit.unitAnimator.SetTrigger("Death");
                    yield return new WaitForSeconds(1f);

                    /*
                    if (midBoss)
                    {
                        playerUnit.Heal(postBossHeal);
                        playerHUD.SetHP(playerUnit.currentHP);
                        HealText.Create(healTextPrefab, playerHealText, postBossHeal);
                        yield return new WaitForSeconds(1f);
                    }
                    */
                    
                    state = BattleState.WON;
                    EndBattle();
                }

                else
                {
                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());
                }

                if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 7)
                {
                    DataHolder.Instance.tutorialIndex++;
                }                

                yield return new WaitForSeconds(2f);
            }



            else if (DataHolder.Instance.ascensionMode == true)
            {
                if (ascensionBattle.usedAttack == true)
                {
                    bool isDead = enemyUnit.TakeDamage(ascensionBattle.ascensionDamage + tempRestBoost);

                    playerUnit.unitAnimator.SetTrigger("Attack");

                    yield return new WaitForSeconds(0.1f);

                    enemyUnit.unitAnimator.SetTrigger("Hit");

                    enemyHUD.SetHP(enemyUnit.currentHP);

                    DamageText.Create(damageTextPrefab, enemyDamageText, ascensionBattle.ascensionDamage + tempRestBoost);

                    if (isDead)
                    {
                        enemyUnit.unitAnimator.SetTrigger("Death");
                        yield return new WaitForSeconds(1f);
                        /*
                        if  (midBoss)
                        {
                            playerUnit.Heal(postBossHeal);
                            playerHUD.SetHP(playerUnit.currentHP);
                            HealText.Create(healTextPrefab, playerHealText, postBossHeal);
                            yield return new WaitForSeconds(1f);
                        }
                        */

                        state = BattleState.WON;
                        EndBattle();
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        StartCoroutine(EnemyTurn());
                    }

                    ascensionBattle.usedAttack = false;

                    yield return new WaitForSeconds(2f);
                }
                else if (ascensionBattle.usedBlock == true)
                {
                    blockDamageReduc += ascensionBattle.ascensionBlock;

                    ascensionBattle.usedBlock = false;

                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());

                    yield return new WaitForSeconds(2f);
                }
                else if(ascensionBattle.usedRest == true)
                {
                    playerUnit.Heal(ascensionBattle.ascensionHealing);
                    playerHUD.SetHP(playerUnit.currentHP);
                    HealText.Create(healTextPrefab, playerHealText, ascensionBattle.ascensionHealing);

                    tempRestBoost += ascensionBattle.ascensionBoost;
                    healUses -= 1;

                    ascensionBattle.usedRest = false;

                    state = BattleState.ENEMYTURN;
                    StartCoroutine(EnemyTurn());

                    yield return new WaitForSeconds(2f);
                }
            }     
        }
    }

    IEnumerator EnemyTurn()
    {
        attacks.SetActive(false);
        
        //Indication of attack, animation, text, w/e
        battleText.text = "Enemy Turn";

        yield return new WaitForSeconds(1f);

        StartCoroutine(CalculateEnemyAttack());

        enemyUnit.unitAnimator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.1f);

        playerUnit.unitAnimator.SetTrigger("Hit");

        bool isDead = playerUnit.TakeDamage(enemyCalc);
        //Creates the damage numbers next to the player.
        DamageText.Create(damageTextPrefab, playerDamageText, enemyCalc);

        yield return new WaitForSeconds(0.01f);

        playerUnit.SetPlayerHP();

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            playerUnit.unitAnimator.SetTrigger("Death");
            yield return new WaitForSeconds(1f);
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            canAttack = true;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            if (finalBoss)
            {
                //Set up a bool that is set for boss battles, and call a win screen when boss is defeated. Have stats of the run and buttons.
                winloseScreen.WinScreen();

                DataHolder.Instance.currentIndex = 0;
                
                if (DataHolder.Instance.descensionMode == true)
                {
                    DataHolder.Instance.descensionMode = false;
                }
                else if (DataHolder.Instance.ascensionMode == true)
                {
                    DataHolder.Instance.ascensionMode = false;
                }
            }
            else
            {
                if (DataHolder.Instance.descensionMode == true)
                {
                    //Weapon selection screen
                    battleText.text = "Battle Won!";
                    weaponSelect.SetActive(true);
                    weaponSelectArt.ChangeWeaponSelectImage();
                    
                    if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 0)
                    {
                        DataHolder.Instance.tutorialIndex++;
                    }
                    else if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 4)
                    {
                        DataHolder.Instance.tutorialIndex++;
                    }
                    else if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 8)
                    {
                        DataHolder.Instance.tutorialIndex++;
                    }
                }
                else if (DataHolder.Instance.ascensionMode == true)
                {
                    //Select upgrade of choice.
                    battleText.text = "Battle Won!";
                    ascUpgradeSelect.SetActive(true);
                    upgradeArt.ChangeUpgradeArt();
                }
            }
            

        }
        else if (state == BattleState.LOST)
        {
            //Lose screen/game over, menu that leads to main menu
            //Pull up a hidden Game Over screen. Have stats of the run and button that leads to main menu.
            winloseScreen.LoseScreen();
        }
    }

    void PlayerTurn()
    {
        battleText.text = "Player Turn";
        attacks.SetActive(true);
        if (blockDamageReduc > 0)
        {
            blockDamageReduc -= 1;
        }
        
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }

    IEnumerator CalculateEnemyAttack()
    {
        enemyCalc = enemyUnit.damage - blockDamageReduc;

        if (enemyCalc < 0)
        {
            enemyCalc = 0;
        }

        yield return null;
    }

    IEnumerator CalculateDamage(int rawDmg, WeaponElement attackElement, WeaponAlignment attackAlignment, WeaponType attackBPS)
    {
        ElementCheck(attackElement);
        AlignmentCheck(attackAlignment);
        BPSCheck(attackBPS);

        yield return new WaitForSeconds(0.01f);

        finalDamage = (int)(rawDmg * elementMultiplier * alignmentMultiplier * bpsMultiplier);

        Debug.Log("Base Damage: " + rawDmg.ToString() + ", Elemental Multiplier: " + elementMultiplier.ToString() + ", Alignment Multiplier: " + 
        alignmentMultiplier.ToString() + ", Weapon Type Multiplier: " + bpsMultiplier.ToString());
    }

    private void ElementCheck(WeaponElement checkElement)
    {
        switch (booton.wElement)
        {
            case WeaponElement.Fire:
                if (enemyUnit.cElement == UnitElement.Fire)
                {
                    //Have enemies absorb elemental attacks that nulls the damage and benefits them (heal, damage boost, etc.)
                    elementMultiplier = elementNotEffective;
                    enemyAbsorb = true;
                    Debug.Log("It's not effective. The enemy absorbed the elemental attack!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Grass)
                {
                    elementMultiplier = elementSuperEffective;
                    Debug.Log("It's very effective!");
                    return;
                }
                else
                {
                    elementMultiplier = neutralDamage;
                }
                break;
            case WeaponElement.Water:
                if (enemyUnit.cElement == UnitElement.Water)
                {
                    //Have enemies absorb elemental attacks that nulls the damage and benefits them (heal, damage boost, etc.)
                    elementMultiplier = elementNotEffective;
                    enemyAbsorb = true;
                    Debug.Log("It's not effective. The enemy absorbed the elemental attack!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Fire)
                {
                    elementMultiplier = elementSuperEffective;
                    Debug.Log("It's very effective!");
                    return;
                }
                else
                {
                    elementMultiplier = neutralDamage;
                }
                break;
            case WeaponElement.Grass:
                if (enemyUnit.cElement == UnitElement.Grass)
                {
                    //Have enemies absorb elemental attacks that nulls the damage and benefits them (heal, damage boost, etc.)
                    elementMultiplier = elementNotEffective;
                    enemyAbsorb = true;
                    Debug.Log("It's not effective. The enemy absorbed the elemental attack!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Water)
                {
                    elementMultiplier = elementSuperEffective;
                    Debug.Log("It's very effective!");
                    return;
                }
                else
                {
                    elementMultiplier = neutralDamage;
                }
                break;
            default:
                elementMultiplier = neutralDamage;
                return;
        }
    }

    private void AlignmentCheck(WeaponAlignment checkAlignment)
    {
        switch (booton.wAlignment)
        {
            case WeaponAlignment.Light:
                if (enemyUnit.cAlignment == UnitAlignment.Dark)
                {
                    alignmentMultiplier = alignmentSuperEffective;
                    return;
                }
                else if (enemyUnit.cAlignment == UnitAlignment.Light)
                {
                    alignmentMultiplier = alignmentNotEffective;
                    return;
                }
                else
                {
                    alignmentMultiplier = neutralDamage;
                }
                break;
            case WeaponAlignment.Dark:
                if (enemyUnit.cAlignment == UnitAlignment.Light)
                {
                    alignmentMultiplier = alignmentSuperEffective;
                    return;
                }
                else if (enemyUnit.cAlignment == UnitAlignment.Dark)
                {
                    alignmentMultiplier = alignmentNotEffective;
                    return;
                }
                else
                {
                    alignmentMultiplier = neutralDamage;
                }
                break;  
            default:
                alignmentMultiplier = neutralDamage;
                return;
        }
    }

    private void BPSCheck(WeaponType checkBPS)
    {
        switch (booton.wType)
        {
            case WeaponType.Bludgeon:
                if (enemyUnit.cResistBPS == UnitWeaponResistance.Bludgeon)
                {
                    bpsMultiplier = bpsNotEffective;
                    return;
                }
                else if (enemyUnit.cWeakBPS == UnitWeaponWeakness.Bludgeon)
                {
                    bpsMultiplier = bpsSuperEffective;
                    return;
                }
                else
                {
                    bpsMultiplier = neutralDamage;
                }
                break;
            case WeaponType.Pierce:
                if (enemyUnit.cResistBPS == UnitWeaponResistance.Pierce)
                {
                    bpsMultiplier = bpsNotEffective;
                    return;
                }
                else if (enemyUnit.cWeakBPS == UnitWeaponWeakness.Pierce)
                {
                    bpsMultiplier = bpsSuperEffective;
                    return;
                }
                else
                {
                    bpsMultiplier = neutralDamage;
                }
                break;
            case WeaponType.Slash:
                if (enemyUnit.cResistBPS == UnitWeaponResistance.Slash)
                {
                    bpsMultiplier = bpsNotEffective;
                    return;
                }
                else if (enemyUnit.cWeakBPS == UnitWeaponWeakness.Slash)
                {
                    bpsMultiplier = bpsSuperEffective;
                    return;
                }
                else
                {
                    bpsMultiplier = neutralDamage;
                }
                break;
            case WeaponType.Magic:
                {
                    bpsMultiplier = bpsSuperEffective;
                }
                break;
            default:
                bpsMultiplier = neutralDamage;
                return;
        }
    }

    private void ElementBoost(int amount)
    {
        if (enemyAbsorb)
        {
            enemyUnit.damage += amount;
        }
    }

    private void ChangeBackground()
    {
        if (DataHolder.Instance.currentIndex == 0)
        {
            bedroom.SetActive(true);
            hallway1.SetActive(false);
            hallway2.SetActive(false);
            bottomFloor.SetActive(false);
            towerTop.SetActive(false);
        }
        if (DataHolder.Instance.currentIndex > 0 && DataHolder.Instance.currentIndex < 4)
        {
            bedroom.SetActive(false);
            hallway1.SetActive(true);
            hallway2.SetActive(false);
            bottomFloor.SetActive(false);
            towerTop.SetActive(false);
        }
        if (DataHolder.Instance.currentIndex > 3 && DataHolder.Instance.currentIndex < 5)
        {
            bedroom.SetActive(false);
            hallway1.SetActive(false);
            hallway2.SetActive(true);
            bottomFloor.SetActive(false);
            towerTop.SetActive(false);
        }
        if (finalBoss)
        {
            if(DataHolder.Instance.descensionMode == true)
            {
                bedroom.SetActive(false);
                hallway1.SetActive(false);
                hallway2.SetActive(false);
                bottomFloor.SetActive(true);
                towerTop.SetActive(false);
            }
            else if(DataHolder.Instance.ascensionMode == true)
            {
                bedroom.SetActive(false);
                hallway1.SetActive(false);
                hallway2.SetActive(false);
                bottomFloor.SetActive(false);
                towerTop.SetActive(true);
            }
        }
    }
}
