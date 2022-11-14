using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapMover : MonoBehaviour
{
    public GameObject Player;
    public bool inTransition;
    public int ySpace;
    public int arrayIndex = 0;
    public MapSpawn mapSpawnScript;
    [SerializeField]
    private TransitionScript sceneTransitionMap;
    

    // Start is called before the first frame update
    void Start()
    {
        inTransition = false;
        ySpace = 3;
        arrayIndex = DataHolder.Instance.currentIndex;   
    }

    // Update is called once per frame
    void Update()
    {
        Player.transform.position = DataHolder.Instance.positionManager.transform.position;
    }

    private void OnMouseDown()
    {
        if (!inTransition)
        {
            if (Player.transform.position.y >= this.transform.position.y && this.transform.position.y == Player.transform.position.y - ySpace)
            {
                Player.transform.position = this.transform.position;
                DataHolder.Instance.positionManager.transform.position = this.transform.position;
                inTransition = true;
                

                mapSpawnScript.PickEnemy();
                mapSpawnScript.PickWeapon();
                mapSpawnScript.PickUpgrades();

                StartCoroutine(SceneManagerAndMovement());
            }
            else
            {
                Debug.Log("You cannot move here.");
            }
        }
    }

    IEnumerator SceneManagerAndMovement()
    {
        arrayIndex++;
        DataHolder.Instance.currentIndex = arrayIndex;
        yield return new WaitForSeconds(.5f);
        sceneTransitionMap.MapToBattleTransition();
        yield return null;
    }
}
