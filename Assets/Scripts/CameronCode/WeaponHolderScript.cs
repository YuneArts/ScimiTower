using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolderScript : MonoBehaviour
{
    private int maxInventory = 4;
    public int currentInventory = 1;
    public GameObject[] slots;
    public BattleSystem battleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentInventory = battleSystem.inven;
        if (currentInventory == 1)
        {
            slots[1].SetActive(false);
            slots[2].SetActive(false);
            slots[3].SetActive(false);
        }
    }
}
