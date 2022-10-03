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
    public WeaponElement wElement;
    public BattleSystem battleSystem;
    
    public void ToMap()
    {
        SceneManager.LoadScene("MapScene");
        
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
        if (inventory.Container[0].durability > 0 && battleSystem.canAttack == true)
        {
            wDamage = inventory.Container[0].attack;
            wElement = inventory.Container[0].element;
            inventory.Container[0].durability -= 1;
            bSystem.OnAttackButton();
            battleSystem.canAttack = false;
        }
    }

    public void SlotAttack2()
    {
        if (inventory.Container[1].durability > 0 && battleSystem.canAttack == true)
        {
            wDamage = inventory.Container[1].attack;
            wElement = inventory.Container[1].element;
            inventory.Container[1].durability -= 1;
            bSystem.OnAttackButton();
            battleSystem.canAttack = false;
        }
    }

    public void SlotAttack3()
    {
        if (inventory.Container[2].durability > 0 && battleSystem.canAttack == true)
        {
            wDamage = inventory.Container[2].attack;
            wElement = inventory.Container[2].element;
            inventory.Container[2].durability -= 1;
            bSystem.OnAttackButton();
            battleSystem.canAttack = false;
        }
    }

    public void SlotAttack4()
    {
        if (inventory.Container[3].durability > 0 && battleSystem.canAttack == true)
        {
            wDamage = inventory.Container[3].attack;
            wElement = inventory.Container[3].element;
            inventory.Container[3].durability -= 1;
            bSystem.OnAttackButton();
            battleSystem.canAttack = false;
        }
    }

    public void WeaponBreak()
    {
        if (inventory.Container[0].durability == 0)
        {
            inventory.Container.Remove(inventory.Container[0]);
        }

        /*Do this for all four weapon slots. This is example code/idea for how to do it. 
          Might have to reference weapon holder script here or put this within that script to keep slot enabling and disabling within the same space. */
    }
}
