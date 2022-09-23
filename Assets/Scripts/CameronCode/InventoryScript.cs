using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryScript : ScriptableObject
{
    public List<WeaponData> Container = new List<WeaponData>();
    public void AddWeapon(WeaponData weapon)
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
