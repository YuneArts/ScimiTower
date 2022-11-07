using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    //public BattleSystem batSystem;
    public EnemySelect enemyPool;
    public InventoryScript weaponPool;
    public UpgradeSelect upgradePool;

    public void PickEnemy()
    {
        int randomIndex = Random.Range(0, enemyPool.Container.Count);
        //Debug.Log("Picked enemy.");
        /*
        switch (randomIndex)
        {
            case 1:
                DataHolder.Instance.mapEnemySpawn = enemyPool.Container[0];
                break;
            case 2:
                DataHolder.Instance.mapEnemySpawn = enemyPool.Container[1];
                break;
            case 3:
                DataHolder.Instance.mapEnemySpawn = enemyPool.Container[2];
                break;
            case 4:
                DataHolder.Instance.mapEnemySpawn = enemyPool.Container[3];
                break;
            default:
                DataHolder.Instance.mapEnemySpawn = enemyPool.Container[0];
                break;
        }
        */
        SetEnemy(randomIndex); 
    }

    private void SetEnemy(int indexPick)
    {
        DataHolder.Instance.mapEnemySpawn = enemyPool.Container[indexPick];
        Debug.Log("Picked: " + enemyPool.Container[indexPick].unitName);
    }

    public void PickWeapon()
    {
        if (DataHolder.Instance.descensionMode == true)
        {
            int randomIndex = Random.Range(0, weaponPool.Container.Count);
            //Debug.Log("Picked enemy.");

            /*
            switch (randomIndex)
            {
                case 1:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[0];
                    break;
                case 2:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[1];
                    break;
                case 3:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[2];
                    break;
                case 4:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[3];
                    break;
                case 5:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[4];
                    break;
                case 6:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[5];
                    break;
                case 7:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[6];
                    break;
                case 8:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[7];
                    break;
                case 9:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[8];
                    break;
                case 10:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[9];
                    break;
                default:
                    DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[0];
                    break;
            }
            */

            SetWeapon(randomIndex);
        }
    }

    private void SetWeapon(int weaponPick)
    {
        DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[weaponPick];
        Debug.Log("Picked: " + weaponPool.Container[weaponPick].weaponName);
    }

    public void PickUpgrades()
    {
        if  (DataHolder.Instance.ascensionMode == true)
        {
            int upgrade1 = Random.Range(0, upgradePool.Container.Count);

            int upgrade2 = Random.Range(0, upgradePool.Container.Count);

            int upgrade3 = Random.Range(0, upgradePool.Container.Count);

            DataHolder.Instance.mapUpgrade1 = upgradePool.Container[upgrade1];

            DataHolder.Instance.mapUpgrade2 = upgradePool.Container[upgrade2];

            DataHolder.Instance.mapUpgrade3 = upgradePool.Container[upgrade3];

            StartCoroutine(RerollUpgrades());
        }  
    }

    IEnumerator RerollUpgrades()
    {
        while (DataHolder.Instance.mapUpgrade2 == DataHolder.Instance.mapUpgrade1 || DataHolder.Instance.mapUpgrade2 == DataHolder.Instance.mapUpgrade3)
        {
            int reroll = Random.Range(0, upgradePool.Container.Count);

            DataHolder.Instance.mapUpgrade2 = upgradePool.Container[reroll];
            Debug.Log("Rerolled upgrade.");
            yield return null;
        }

        yield return new WaitForSeconds(0.01f);

        while (DataHolder.Instance.mapUpgrade3 == DataHolder.Instance.mapUpgrade1 || DataHolder.Instance.mapUpgrade3 == DataHolder.Instance.mapUpgrade2)
        {
            int reroll = Random.Range(0, upgradePool.Container.Count);

            DataHolder.Instance.mapUpgrade3 = upgradePool.Container[reroll];
            Debug.Log("Rerolled upgrade.");
            yield return null;
        }
    }
}
