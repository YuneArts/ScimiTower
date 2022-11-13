using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    [SerializeField]
    private Animator transitionAnim;
    
    //Time that coroutine takes before loading the scene. Can edit within Inspector.
    [SerializeField]
    private float transitionTime;

    //Public function that starts the transition at the end of a battle before loading the map scene.
    public void BattleToMapTransition()
    {
        StartCoroutine(ReturnToMap());
    }

    public void MapToBattleTransition()
    {
        StartCoroutine(EnterBattle());
    }

    IEnumerator ReturnToMap()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 2 || DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 6)
        {
            DataHolder.Instance.tutorialIndex++;
        }

        SceneManager.LoadScene("MapScene");
    }

    IEnumerator EnterBattle()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 3)
        {
            DataHolder.Instance.tutorialIndex++;
        }
        else if(DataHolder.Instance.tutorialEnabled == true && DataHolder.Instance.tutorialIndex == 5)
        {
            DataHolder.Instance.tutorialIndex++;
        }

        if (DataHolder.Instance.ascensionMode == true)
        {
            SceneManager.LoadScene("AscensionBattle");
        }
        else if (DataHolder.Instance.descensionMode == true)
        {
            SceneManager.LoadScene("BattleScreen");
        }
    }
}
