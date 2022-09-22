using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject weaponSlots;
    public GameObject option;
    
    public void ToMap()
    {
        SceneManager.LoadScene(1);
        
    }

    public void SlotSelect()
    {
        weaponSlots.SetActive(true);
        option.SetActive(false);
    }
}
