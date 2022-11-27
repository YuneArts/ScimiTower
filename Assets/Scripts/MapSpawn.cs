using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField]
    private EnemySelect enemyPool;
    [SerializeField]
    private InventoryScript weaponPool;
    [SerializeField]
    private UpgradeSelect upgradePool;

    public void PickEnemy()
    {
        int randomIndex = Random.Range(0, enemyPool.Container.Count);
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
