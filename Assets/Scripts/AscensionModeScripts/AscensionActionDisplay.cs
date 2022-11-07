using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AscensionActionDisplay : MonoBehaviour
{
    public AscensionModeActions ascActions;
    public Image actionArt;

    void Start()
    {
        actionArt.sprite = ascActions.ascSprite;
        //sharedDurabilityText.text = ascActions.durabilityValue.ToString();
    }
}