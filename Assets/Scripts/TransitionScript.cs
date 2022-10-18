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

        SceneManager.LoadScene("MapScene");
    }

    IEnumerator EnterBattle()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("BattleScreen");
    }
}
