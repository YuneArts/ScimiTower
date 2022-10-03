using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    private void Update()
    {
        if (isPaused == true)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(false);
        }
    }

    public void pauseOn()
    {
        isPaused = true;
    }

    public void pauseOff()
    {
        isPaused = false;
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
