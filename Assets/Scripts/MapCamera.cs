using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject mapCamera;
    [SerializeField]
    private Transform camSpot1, camSpot2, camSpot3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DataHolder.Instance.currentIndex > 2 && DataHolder.Instance.currentIndex < 5)
        {
            mapCamera.transform.position = camSpot2.transform.position;
        }
        else if (DataHolder.Instance.currentIndex > 4)
        {
            mapCamera.transform.position = camSpot3.transform.position;
        }
        else
        {
            mapCamera.transform.position = camSpot1.transform.position;
        }
    }
}
