using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEvents : MonoBehaviour
{
    [SerializeField]
    private UnitData player;
    [SerializeField]
    private GameObject healPrefab;
    [SerializeField]
    private Transform healTextSpot;

    public void HealEvent()
    {
        player.uCurrentHP += 30;

        if(player.uCurrentHP >= 80)
        {
            player.uCurrentHP = 80;
        }
        
        HealText.Create(healPrefab, healTextSpot, 30);
    }
}
