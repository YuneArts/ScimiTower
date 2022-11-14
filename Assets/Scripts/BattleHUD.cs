using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    public Text cHP;
    public Text mHP;

    public void SetHUD(Unit unit)
    {
        unit.currentHP = (int)Mathf.Clamp(unit.maxHP, 0, unit.maxHP);
        nameText.text = unit.cName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        cHP.text = unit.currentHP.ToString();
        mHP.text = unit.maxHP.ToString();
    }

    public void SetHP(int hp)
    {  
        hpSlider.value = hp;
        cHP.text = hp.ToString();
        if (hp < 0)
        {
            hp = 0;
        }
    }
}
