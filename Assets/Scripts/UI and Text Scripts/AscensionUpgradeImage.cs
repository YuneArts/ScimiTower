using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AscensionUpgradeImage : MonoBehaviour
{
    [SerializeField]
    //private AscensionUpgrade buttonUpgrade1, buttonUpgrade2, buttonUpgrade3;
    public Image buttonImage1, buttonImage2, buttonImage3;

    void Awake()
    {
        //buttonUpgrade1 = DataHolder.Instance.mapUpgrade1;
        //buttonUpgrade2 = DataHolder.Instance.mapUpgrade2;
        //buttonUpgrade3 = DataHolder.Instance.mapUpgrade3;
    }

    public void ChangeUpgradeArt()
    {
        buttonImage1.sprite = DataHolder.Instance.mapUpgrade1.upSprite;
        buttonImage2.sprite = DataHolder.Instance.mapUpgrade2.upSprite;
        buttonImage3.sprite = DataHolder.Instance.mapUpgrade3.upSprite;
    }
}
