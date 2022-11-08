using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoSOWeapons
{
    private static string weaponCSVPath = "/Editor/CSV Files/ScimiTower Maths - Weapon Export.csv";

    [MenuItem("Utilities/GenerateWeapons")]
    public static void GenerateWeapons()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + weaponCSVPath);

        foreach(string s in allLines)
        {
            string[] splitData = s.Split(',');

            WeaponData weapon = ScriptableObject.CreateInstance<WeaponData>();
            weapon.weaponName = splitData[0];
            weapon.durability = int.Parse(splitData[1]);
            weapon.maxDurability = int.Parse(splitData[1]);
            
            if (splitData[3] == "None")
            {
                weapon.element = WeaponElement.None;
            }
            else if (splitData[3] == "Fire")
            {
                weapon.element = WeaponElement.Fire;
            }
            else if (splitData[3] == "Water")
            {
                weapon.element = WeaponElement.Water;
            }
            else if (splitData[3] == "Grass")
            {
                weapon.element = WeaponElement.Grass;
            }

            if (splitData[4] == "None")
            {
                weapon.alignment = WeaponAlignment.None;
            }
            else if (splitData[4] == "Light")
            {
                weapon.alignment = WeaponAlignment.Light;
            }
            else if (splitData[4] == "Dark")
            {
                weapon.alignment = WeaponAlignment.Dark;
            }

            if (splitData[5] == "None")
            {
                weapon.weaponBPS = WeaponType.None;
            }
            else if (splitData[5] == "B")
            {
                weapon.weaponBPS = WeaponType.Bludgeon;
            }
            else if (splitData[5] == "P")
            {
                weapon.weaponBPS = WeaponType.Pierce;
            }
            else if (splitData[5] == "S")
            {
                weapon.weaponBPS = WeaponType.Slash;
            }
            else 
            {
                weapon.weaponBPS = WeaponType.None;
            }

            AssetDatabase.CreateAsset(weapon, $"Assets/Scriptable Objects/Weapons Export/{weapon.weaponName}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
