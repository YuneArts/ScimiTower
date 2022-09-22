using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryScript : ScriptableObject
{
    public List<WeaponDataSO> Container = new List<WeaponDataSO>();
    public void AddWeapon(WeaponDataSO weapon)
    {
        int inventorySpace = 4;
        int currentInventory = 1;
        bool hasSpace = true;
        if (hasSpace == true && inventorySpace > 4)
        {
            Container.Add(weapon);
            currentInventory++;
        }
    }
}
