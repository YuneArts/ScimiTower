using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoSOEnemies
{
    private static string enemyCSVPath = "/CSV Files/ScimiTower Maths - Enemy Export.csv";

    [MenuItem("Utilities/Generate Enemies")]
    public static void GenerateEnemies()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + enemyCSVPath);

        foreach(string s in allLines)
        {
            string[] splitData = s.Split(',');

            UnitData enemy = ScriptableObject.CreateInstance<UnitData>();
            enemy.unitName = splitData[0];
            enemy.uMaxHP = int.Parse(splitData[1]);
            enemy.uCurrentHP = int.Parse(splitData[1]);
            enemy.uDamage = int.Parse(splitData[2]);

            if (splitData[3] == "None")
            {
                enemy.uElement = UnitElement.None;
            }
            else if (splitData[3] == "Fire")
            {
                enemy.uElement = UnitElement.Fire;
            }
            else if (splitData[3] == "Water")
            {
                enemy.uElement = UnitElement.Water;
            }
            else if (splitData[3] == "Grass")
            {
                enemy.uElement = UnitElement.Grass;
            }

            if (splitData[4] == "None")
            {
                enemy.uAlignment = UnitAlignment.None;
            }
            else if (splitData[4] == "Light")
            {
                enemy.uAlignment = UnitAlignment.Light;
            }
            else if (splitData[4] == "Dark")
            {
                enemy.uAlignment = UnitAlignment.Dark;
            }

            if (splitData[5] == "None")
            {
                enemy.uWeakBPS = UnitWeaponWeakness.None;
            }
            else if (splitData[5] == "B")
            {
                enemy.uWeakBPS = UnitWeaponWeakness.Bludgeon;
            }
            else if (splitData[5] == "P")
            {
                enemy.uWeakBPS = UnitWeaponWeakness.Pierce;
            }
            else if (splitData[5] == "S")
            {
                enemy.uWeakBPS = UnitWeaponWeakness.Slash;
            }
            else 
            {
                enemy.uWeakBPS = UnitWeaponWeakness.None;
            }

            AssetDatabase.CreateAsset(enemy, $"Assets/Scriptable Objects/Enemies Export/{enemy.unitName}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
