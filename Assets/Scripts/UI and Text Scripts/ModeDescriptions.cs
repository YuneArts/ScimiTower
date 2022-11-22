using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ModeDescriptions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI modeTitle;
    [SerializeField]
    private GameObject modeWindow, modeDescription, otherDescription;
    [SerializeField]
    private string modeName;

    public void ModeWindowEnable()
    {
        modeWindow.SetActive(true);
    }

    public void ModeWindowDisable()
    {
        modeWindow.SetActive(false);
    }

    void OnMouseOver()
    {
        modeTitle.text = modeName;
        modeDescription.SetActive(true);
        otherDescription.SetActive(false);
        Debug.Log("Mode Description Display");
    }
    
    public void ModeDescription()
    {
        modeTitle.text = modeName;
        modeDescription.SetActive(true);
        otherDescription.SetActive(false);
    }
}
