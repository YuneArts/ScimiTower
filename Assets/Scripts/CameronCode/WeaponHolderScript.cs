using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolderScript : MonoBehaviour
{
    private int maxInventory = 4;
    public int currentInventory;
    public GameObject[] slots;
    public BattleSystem battleSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentInventory = battleSystem.inventory.Container.Count;
        slots[0].SetActive(true);

        if (currentInventory == 1)
        {
            slots[1].SetActive(false);
            slots[2].SetActive(false);
            slots[3].SetActive(false);
        }
        else if (currentInventory == 2)
        {
            slots[1].SetActive(true);
            slots[2].SetActive(false);
            slots[3].SetActive(false);
        }
        else if (currentInventory == 3)
        {
            slots[1].SetActive(true);
            slots[2].SetActive(true);
            slots[3].SetActive(false);
        }
        else if (currentInventory == 4)
        {
            slots[1].SetActive(true);
            slots[2].SetActive(true);
            slots[3].SetActive(true);
        }
    }
}
