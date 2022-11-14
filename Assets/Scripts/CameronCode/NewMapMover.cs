using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapMover : MonoBehaviour
{
    public GameObject Player, startingSpot;
    public bool inTransition;
    public int ySpace, arrayIndex;
    public MapSpawn mapSpawnScript;
    [SerializeField]
    private TransitionScript sceneTransitionMap;
    public SpriteRenderer node;
    // Start is called before the first frame update
    void Start()
    {
        inTransition = false;
        ySpace = 3;
        node = GetComponent<SpriteRenderer>();
        arrayIndex = DataHolder.Instance.currentIndex;
        if(DataHolder.Instance.currentIndex == 0)
        {
            DataHolder.Instance.positionManager.transform.position = startingSpot.transform.position;
        }
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
        //arrayIndex = Mathf.Clamp(arrayIndex, 0, spaces);
        DataHolder.Instance.currentIndex = arrayIndex;
        yield return new WaitForSeconds(.5f);
        sceneTransitionMap.MapToBattleTransition();
        yield return null;
    }

    private void OnMouseOver()
    {
        node.color = new Color(0.75f, 0.75f, 0.75f, 1);
    }

    private void OnMouseExit()
    {
        node.color = new Color(1, 1, 1, 1);
    }
}
