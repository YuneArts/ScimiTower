using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScreen : MonoBehaviour
{
    public AscensionUpgrade slotUpgrade1, slotUpgrade2, slotUpgrade3;

    [SerializeField]
    private AscensionModeInventory actionInventory;

    [SerializeField]
    private TransitionScript transition;

    [SerializeField]
    private TextMeshProUGUI name1, name2, name3, desc1, desc2, desc3;

    void Start()
    {
        slotUpgrade1 = DataHolder.Instance.mapUpgrade1;
        slotUpgrade2 = DataHolder.Instance.mapUpgrade2;
        slotUpgrade3 = DataHolder.Instance.mapUpgrade3;
    }

    void Update()
    {
        name1.text = slotUpgrade1.upName;
        name2.text = slotUpgrade2.upName;
        name3.text = slotUpgrade3.upName;

        /*
        desc1.text = slotUpgrade1.description;
        desc2.text = slotUpgrade2.description;
        desc3.text = slotUpgrade3.description;
        */
    }

    public void SelectUpgrade1()
    {
        actionInventory.Container[0].attackValue += slotUpgrade1.upDamage;
        actionInventory.Container[0].durabilityValue += slotUpgrade1.upDurability;
        actionInventory.Container[0].healValue += slotUpgrade1.upHeal;
        actionInventory.Container[0].blockValue += slotUpgrade1.upBlock;

        actionInventory.Container[2].attackValue += slotUpgrade1.upDamage;
        actionInventory.Container[2].durabilityValue += slotUpgrade1.upDurability;
        actionInventory.Container[2].healValue += slotUpgrade1.upHeal;
        actionInventory.Container[2].blockValue += slotUpgrade1.upBlock;

        actionInventory.Container[3].attackValue += slotUpgrade1.upDamage;
        actionInventory.Container[3].durabilityValue += slotUpgrade1.upDurability;
        actionInventory.Container[3].healValue += slotUpgrade1.upHeal;
        actionInventory.Container[3].blockValue += slotUpgrade1.upBlock;

        transition.BattleToMapTransition();
    }

    public void SelectUpgrade2()
    {
        actionInventory.Container[0].attackValue += slotUpgrade2.upDamage;
        actionInventory.Container[0].durabilityValue += slotUpgrade2.upDurability;
        actionInventory.Container[0].healValue += slotUpgrade2.upHeal;
        actionInventory.Container[0].blockValue += slotUpgrade2.upBlock;

        actionInventory.Container[2].attackValue += slotUpgrade2.upDamage;
        actionInventory.Container[2].durabilityValue += slotUpgrade2.upDurability;
        actionInventory.Container[2].healValue += slotUpgrade2.upHeal;
        actionInventory.Container[2].blockValue += slotUpgrade2.upBlock;

        actionInventory.Container[3].attackValue += slotUpgrade2.upDamage;
        actionInventory.Container[3].durabilityValue += slotUpgrade2.upDurability;
        actionInventory.Container[3].healValue += slotUpgrade2.upHeal;
        actionInventory.Container[3].blockValue += slotUpgrade2.upBlock;

        transition.BattleToMapTransition();
    }

    public void SelectUpgrade3()
    {
        actionInventory.Container[0].attackValue += slotUpgrade3.upDamage;
        actionInventory.Container[0].durabilityValue += slotUpgrade3.upDurability;
        actionInventory.Container[0].healValue += slotUpgrade3.upHeal;
        actionInventory.Container[0].blockValue += slotUpgrade3.upBlock;

        actionInventory.Container[2].attackValue += slotUpgrade3.upDamage;
        actionInventory.Container[2].durabilityValue += slotUpgrade3.upDurability;
        actionInventory.Container[2].healValue += slotUpgrade3.upHeal;
        actionInventory.Container[2].blockValue += slotUpgrade3.upBlock;

        actionInventory.Container[3].attackValue += slotUpgrade3.upDamage;
        actionInventory.Container[3].durabilityValue += slotUpgrade3.upDurability;
        actionInventory.Container[3].healValue += slotUpgrade3.upHeal;
        actionInventory.Container[3].blockValue += slotUpgrade3.upBlock;

        transition.BattleToMapTransition();
    }
}
