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
    private GameObject bedroom, hallway1, hallway2, bottomFloor;

    Unit playerUnit;
    Unit enemyUnit;

    public bool canAttack;
    [SerializeField]
    private bool midBoss, finalBoss, enemyAbsorb;

    public GameObject weaponSelect;
    public InventoryScript inventory;
    public List<WeaponDisplay> weaponDisplay;
    public ButtonScript booton;
    public WeaponSelectImage weaponSelectArt;

    private int finalDamage;
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

    void Start()
    {
        canAttack = false;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    private void Update()
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

    IEnumerator SetupBattle()
    {
        //GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerPrefab.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.unitInfo = DataHolder.Instance.mapEnemySpawn;

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemyInfo();

        //yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemySprite();

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
            //Calculate damage past resistances and weaknesses
            StartCoroutine(CalculateDamage(booton.wDamage, booton.wElement, booton.wAlignment, booton.wType));
            //Start healing if weapon action has healing
            if (booton.wHealing > 0)
            {
                playerUnit.Heal(booton.wHealing);
                HealText.Create(healTextPrefab, playerHealText, booton.wHealing);
            }

            yield return new WaitForSeconds(0.05f);

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
                yield return new WaitForSeconds(1f);

                if (midBoss)
                {
                    playerUnit.Heal(postBossHeal);
                    playerHUD.SetHP(playerUnit.currentHP);
                    HealText.Create(healTextPrefab, playerHealText, postBossHeal);
                    yield return new WaitForSeconds(1f);
                }
                
                state = BattleState.WON;
                EndBattle();
            }

            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator EnemyTurn()
    {
        //Indication of attack, animation, text, w/e
        battleText.text = "Enemy Turn";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        //Creates the damage numbers next to the player.
        DamageText.Create(damageTextPrefab, playerDamageText, enemyUnit.damage);

        yield return new WaitForSeconds(0.01f);

        playerUnit.SetPlayerHP();

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
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
            }
            else
            {
                //Weapon selection screen
                battleText.text = "Battle Won!";
                weaponSelect.SetActive(true);
                weaponSelectArt.ChangeWeaponSelectImage();
            }
            

        }
        else if (state == BattleState.LOST)
        {
            //Lose screen/game over, menu that leads to main menu
            battleText.text = "Battle Lost!";
            SceneManager.LoadScene("MainMenu");
            //Pull up a hidden Game Over screen. Have stats of the run and button that leads to main menu.
            winloseScreen.LoseScreen();
        }
    }

    void PlayerTurn()
    {
        battleText.text = "Player Turn";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
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
        }
        if (DataHolder.Instance.currentIndex == 1 || DataHolder.Instance.currentIndex == 2)
        {
            bedroom.SetActive(false);
            hallway1.SetActive(true);
            hallway2.SetActive(false);
            bottomFloor.SetActive(false);
        }
        if (DataHolder.Instance.currentIndex == 3)
        {
            bedroom.SetActive(false);
            hallway1.SetActive(false);
            hallway2.SetActive(true);
            bottomFloor.SetActive(false);
        }
        if (finalBoss)
        {
            bedroom.SetActive(false);
            hallway1.SetActive(false);
            hallway2.SetActive(false);
            bottomFloor.SetActive(true);
        }
    }
}
