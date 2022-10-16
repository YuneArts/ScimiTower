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

    Unit playerUnit;
    Unit enemyUnit;

    public bool canAttack;
    [SerializeField]
    private bool finalBoss;

    public GameObject weaponSelect;
    public InventoryScript inventory;
    public List<WeaponDisplay> weaponDisplay;
    public ButtonScript booton;
    public WeaponSelectImage weaponSelectArt;

    private int finalDamage;

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

        yield return new WaitForSeconds(0.01f);

        enemyUnit.unitInfo = DataHolder.Instance.mapEnemySpawn;

        yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemyInfo();

        yield return new WaitForSeconds(0.01f);

        enemyUnit.UpdateEnemySprite();

        if (enemyUnit.bossUnit == true)
        {
            finalBoss = true;
        }
        else 
        {
            finalBoss = false;
        }

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

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
            CalculateDamage(booton.wDamage, booton.wElement);
            //Start healing if weapon action has healing
            if (booton.wHealing > 0)
            {
                playerUnit.Heal(booton.wHealing);
                HealText.Create(healTextPrefab, playerHealText, booton.wHealing);
            }

            yield return new WaitForSeconds(0.01f);

            //Damage the Enemy
            bool isDead = enemyUnit.TakeDamage(finalDamage);
            playerHUD.SetHP(playerUnit.currentHP);
            enemyHUD.SetHP(enemyUnit.currentHP);
            //Creates the damage numbers next to the enemy.
            DamageText.Create(damageTextPrefab, enemyDamageText, finalDamage);

            yield return new WaitForSeconds(0.01f);

            if (isDead)
            {
                yield return new WaitForSeconds(1f);
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

    void CalculateDamage(int rawDmg, WeaponElement attackElement)
    {
        float superEffective = 1.5f;
        float notEffective = 0.5f;
        float ldSuperEffective = 2f;

        switch (booton.wElement)
        {
            case WeaponElement.Fire:
                if (enemyUnit.cElement == UnitElement.Grass)
                {
                    finalDamage = (int)(rawDmg * superEffective);
                    Debug.Log("It's super effective!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Water || enemyUnit.cElement == UnitElement.Fire)
                {
                    finalDamage = (int)(rawDmg * notEffective);
                    Debug.Log("It's not very effective...");
                }
                else //if (enemyUnit.cElement == UnitElement.None)
                {
                    finalDamage = rawDmg;
                }
                break;
            case WeaponElement.Water:
                if (enemyUnit.cElement == UnitElement.Fire)
                {
                    finalDamage = (int)(rawDmg * superEffective);
                    Debug.Log("It's super effective!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Grass || enemyUnit.cElement == UnitElement.Water)
                {
                    finalDamage = (int)(rawDmg * notEffective);
                    Debug.Log("It's not very effective...");
                    return;
                }
                else //if (enemyUnit.cElement == UnitElement.None)
                {
                    finalDamage = rawDmg;
                }
                break;
            case WeaponElement.Grass:
                if (enemyUnit.cElement == UnitElement.Water)
                {
                    finalDamage = (int)(rawDmg * superEffective);
                    Debug.Log("It's super effective!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Fire || enemyUnit.cElement == UnitElement.Grass)
                {
                    finalDamage = (int)(rawDmg * notEffective);
                    Debug.Log("It's not very effective...");
                    return;
                }
                else //if (enemyUnit.cElement == UnitElement.None)
                {
                    finalDamage = rawDmg;
                }
                break;
            case WeaponElement.Light:
                if (enemyUnit.cElement == UnitElement.Dark)
                {
                    finalDamage = (int)(rawDmg * ldSuperEffective);
                    Debug.Log("It's super effective!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Light)
                {
                    finalDamage = (int)(rawDmg * notEffective);
                    Debug.Log("It's not very effective...");
                    return;
                }
                else //if (enemyUnit.cElement == UnitElement.None)
                {
                    finalDamage = rawDmg;
                }
                break;
            case WeaponElement.Dark:
                if (enemyUnit.cElement == UnitElement.Dark)
                {
                    finalDamage = (int)(rawDmg * ldSuperEffective);
                    Debug.Log("It's super effective!");
                    return;
                }
                else if (enemyUnit.cElement == UnitElement.Light)
                {
                    finalDamage = (int)(rawDmg * notEffective);
                    Debug.Log("It's not very effective...");
                    return;
                }
                else //if (enemyUnit.cElement == UnitElement.None)
                {
                    finalDamage = rawDmg;
                }
                break;
            default:
                finalDamage = rawDmg;
                return;
        }
    }
    
}
