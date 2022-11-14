using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    public Image[] InventoryArt;
    // Start is called before the first frame update
    void Start()
    {
        InventoryArt[0].sprite = DataHolder.Instance.playerInventory.Container[0].art;
        InventoryArt[1].sprite = DataHolder.Instance.playerInventory.Container[1].art;
        InventoryArt[2].sprite = DataHolder.Instance.playerInventory.Container[2].art;
        InventoryArt[3].sprite = DataHolder.Instance.playerInventory.Container[3].art;
    }
}
