using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.cName;
        hpSlider.maxValue = unit.cMaxHP;
        hpSlider.value = unit.cCurrentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
