using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject weaponSlots;
    public GameObject option;

    public InventoryScript inventory;

    [SerializeField]
    private BattleSystem bSystem;

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

    /*SlotAttack functions access the weapon's damage for BattleSystem script to apply damage. Durability is reduced on click and WeaponBreak function will be
    called in battle system. */
    public void SlotAttack1()
    {
        wDamage = inventory.Container[0].attack;
        inventory.Container[0].durability -= 1;
        bSystem.OnAttackButton();
    }

    public void SlotAttack2()
    {
        wDamage = inventory.Container[1].attack;
        inventory.Container[1].durability -= 1;
        bSystem.OnAttackButton();
    }

    public void SlotAttack3()
    {
        wDamage = inventory.Container[2].attack;
        inventory.Container[2].durability -= 1;
        bSystem.OnAttackButton();
    }

    public void SlotAttack4()
    {
        wDamage = inventory.Container[3].attack;
        inventory.Container[3].durability -= 1;
        bSystem.OnAttackButton();
    }

    public void WeaponBreak()
    {
        if (inventory.Container[0].durability == 0)
        {
            //Disable the slot that the weapon broke on.
        }

        /*Do this for all four weapon slots. This is example code/idea for how to do it. 
          Might have to reference weapon holder script here or put this within that script to keep slot enabling and disabling within the same space. */
    }
}
