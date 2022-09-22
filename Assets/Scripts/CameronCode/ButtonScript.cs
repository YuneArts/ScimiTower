using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject weaponSlots;
    public GameObject option;

    public InventoryScript inventory;
    public BattleSystem bSystem;

    public int wDamage;
    public int wDurability;

    
    public void ToMap()
    {
        SceneManager.LoadScene(1);
        
    }

    public void SlotSelect()
    {
        weaponSlots.SetActive(true);
        option.SetActive(false);
    }

    public void SlotAttack1()
    {
        wDamage = inventory.Container[0].attack;
        bSystem.OnAttackButton();
    }

    public void SlotAttack2()
    {
        wDamage = inventory.Container[1].attack;
        bSystem.OnAttackButton();
    }

    public void SlotAttack3()
    {
        wDamage = inventory.Container[2].attack;
        bSystem.OnAttackButton();
    }

    public void SlotAttack4()
    {
        wDamage = inventory.Container[3].attack;
        bSystem.OnAttackButton();
    }
}
