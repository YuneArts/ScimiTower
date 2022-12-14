using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelect : MonoBehaviour
{
    public BattleSystem battleSystem;
    public InventoryScript randomWeapon;
    public InventoryScript playerInventory;
    public WeaponData theWeapon;
    public GameObject[] slots;

    [SerializeField]
    private TransitionScript sceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        Pick();
    }

    void Pick()
    {
        /*
        int randomIndex = Random.Range(1, randomWeapon.Container.Count);
        Debug.Log($"{randomIndex}");

        if (randomIndex == 1)
        {
            theWeapon = randomWeapon.Container[0];
        }
        else if (randomIndex == 2)
        {
            theWeapon = randomWeapon.Container[1];
        }
        else if (randomIndex == 3)
        {
            theWeapon = randomWeapon.Container[2];
        }
        else if (randomIndex == 4)
        {
            theWeapon = randomWeapon.Container[3];
        }
        */
        theWeapon = DataHolder.Instance.mapWeaponSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerInventory.Container.Count == 1)
        //{
        //    slots[2].SetActive(false);
        //    slots[3].SetActive(false);
            
        //}
        //else if (playerInventory.Container.Count == 2)
        //{
        //    slots[2].SetActive(true);
        //    slots[3].SetActive(false);
        //}
        //else if (playerInventory.Container.Count == 3)
        //{
        //    slots[2].SetActive(true);
        //    slots[3].SetActive(true);
        //}
    }

    public void SlotOne()
    {
        playerInventory.Container[0] = Instantiate(theWeapon);
        sceneTransition.BattleToMapTransition();
        
    }
    public void SlotTwo()
    {
        playerInventory.Container[1] = Instantiate(theWeapon);
        sceneTransition.BattleToMapTransition();

    }
    public void SlotThree()
    {
        playerInventory.Container[2] = Instantiate(theWeapon);
        sceneTransition.BattleToMapTransition();

    }
    public void SlotFour()
    {
        playerInventory.Container[3] = Instantiate(theWeapon);
        sceneTransition.BattleToMapTransition();

    }
}
