using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapMover : MonoBehaviour
{
    public GameObject Player;
    public bool inTransition;
    public int ySpace;
    public SpriteRenderer node;
    // Start is called before the first frame update
    void Start()
    {
        inTransition = false;
        ySpace = 3;
        node = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!inTransition)
        {
            if (Player.transform.position.y <= this.transform.position.y && this.transform.position.y == Player.transform.position.y + ySpace)
            {
                Player.transform.position = this.transform.position;
                inTransition = true;
            }
            else
            {
                Debug.Log("You cannot move here.");
            }
        }
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
