using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    //public BattleSystem batSystem;
    public EnemySelect enemyPool;
    public InventoryScript weaponPool;

    public void PickEnemy()
    {
        int randomIndex = Random.Range(0, enemyPool.Container.Count);
        Debug.Log("Picked enemy.");

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
    }

    public void PickWeapon()
    {
        int randomIndex = Random.Range(0, weaponPool.Container.Count);
        Debug.Log("Picked enemy.");

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
    }
}
