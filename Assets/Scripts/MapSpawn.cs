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
            default:
                DataHolder.Instance.mapWeaponSpawn = weaponPool.Container[0];
                break;
        }
    }
}
