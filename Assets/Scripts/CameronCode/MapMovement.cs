using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 mapLocation;
    public GameObject[] locations;
    public int arrayIndex = 0;
    public int spaces = 3;
    public bool inTransition = false;
    public MapSpawn mapSpawnScript;

    [SerializeField]
    private Transform startingPoint;

    [SerializeField]
    private TransitionScript sceneTransitionMap;

    // Start is called before the first frame update
    void Start()
    {
        arrayIndex = DataHolder.Instance.currentIndex;        
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = locations[arrayIndex].transform.position;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnMouseDown()
    {
        if (!inTransition)
        {
            StartCoroutine(SceneManagerAndMovement());
            inTransition = true;
        }

        mapSpawnScript.PickEnemy();
        mapSpawnScript.PickWeapon();
    }

    public void playerMoveTo()
    {
        if(!inTransition)
        {
            StartCoroutine(SceneManagerAndMovement());
            inTransition = true;
        }
    }

    IEnumerator SceneManagerAndMovement()
    {
        arrayIndex++;
        arrayIndex = Mathf.Clamp(arrayIndex, 0, spaces);
        DataHolder.Instance.currentIndex = arrayIndex;
        yield return new WaitForSeconds(.5f);
        sceneTransitionMap.MapToBattleTransition();
        yield return null;
    }
}
