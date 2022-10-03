using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //public BattleSystem batSystem;
    public EnemySelect enemyPool;

    public void PickEnemy()
    {
        int randomIndex = Random.Range(0, enemyPool.Container.Count);
        Debug.Log("Picked enemy.");

        switch (randomIndex)
        {
            case 1:
                DataHolder.Instance.mapTileUnit = enemyPool.Container[0];
                break;
            case 2:
                DataHolder.Instance.mapTileUnit = enemyPool.Container[1];
                break;
            case 3:
                DataHolder.Instance.mapTileUnit = enemyPool.Container[2];
                break;
            case 4:
                DataHolder.Instance.mapTileUnit = enemyPool.Container[3];
                break;
            default:
                DataHolder.Instance.mapTileUnit = enemyPool.Container[0];
                break;
        }
    }
}
