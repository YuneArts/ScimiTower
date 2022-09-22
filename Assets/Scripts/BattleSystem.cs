using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

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

    public GameObject weaponSelect;
    public InventoryScript inventory;
    public List<WeaponDisplay> weaponDisplay;

    void Start()
    {
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
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        if (state == BattleState.PLAYERTURN)
        {
            //Damage the Enemy
            bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
            enemyHUD.SetHP(enemyUnit.currentHP);

            yield return new WaitForSeconds(0.1f);

            if (isDead)
            {
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

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            //Weapon selection screen
            battleText.text = "Battle Won!";
            weaponSelect.SetActive(true);
        }
        else if (state == BattleState.LOST)
        {
            //Lose screen/game over, menu that leads to main menu
            battleText.text = "Battle Lost!";
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
}
