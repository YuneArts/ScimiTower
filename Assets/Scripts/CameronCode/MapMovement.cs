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
    public int spaces = 2;
    public bool inTransition = false;

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
        SceneManager.LoadScene("BattleScreen");
        yield return null;
    }
}
