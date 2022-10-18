using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject resultsUI, pauseButton;

    [SerializeField]
    private TextMeshProUGUI titleText, titleSubText, weaponCountText, enemyCountText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinScreen()
    {
        resultsUI.SetActive(true);
        pauseButton.SetActive(false);
        titleText.text = "Victory!";
        titleSubText.text = "You safely escaped the tower.";
    }

    public void LoseScreen()
    {
        resultsUI.SetActive(true);
        pauseButton.SetActive(false);
        titleText.text = "Defeat...";
        titleSubText.text = "You failed the descent.";
    }

    public void UpdateResultsScreen()
    {
        weaponCountText.text = "Weapons Obtained: " + DataHolder.Instance.weaponCountStat.ToString();
        enemyCountText.text = "Enemies Slain: " + DataHolder.Instance.enemyCountStat.ToString();
    }
}
