using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;
    
    void Update()
    {
        AdvanceTutorial();
        
        if(DataHolder.Instance.tutorialEnabled == true)
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                if(i == popUpIndex)
                {
                    popUps[i].SetActive(true);
                }
                else
                {
                    popUps[i].SetActive(false);
                }
            }  
        }
        else if(DataHolder.Instance.tutorialEnabled == false)
        {
            for (int i = 0; i < popUps.Length; i++)
            {
                popUps[i].SetActive(false);
            }
        }
         
    }

    public void AdvanceTutorial()
    {
        popUpIndex = DataHolder.Instance.tutorialIndex;
    }
}
