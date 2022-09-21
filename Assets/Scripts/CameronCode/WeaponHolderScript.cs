using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolderScript : MonoBehaviour
{
    //private int maxInventory = 4; Not used atm but we will use it when adding weapons to the screen works.
    public int currentInventory = 1;
    public GameObject[] slots;
    public BattleSystem battleSystem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInventory == 1)
        {
            slots[1].SetActive(false);
            slots[2].SetActive(false);
            slots[3].SetActive(false);
        }
    }
}
