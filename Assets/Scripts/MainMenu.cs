using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

//Back() is for Credits button; Return() is for Settings button.
{
    public int gameStart;

    public AudioSource audio;

    public void playButton()
    {
      audio.Play();
    }

     void quitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void StartGame() 
    {
      SceneManager.LoadScene("BattleScreen");
    }

    public void Credits()
    {
      SceneManager.LoadScene("Credits");
    }
    
    public void Back()
    {
      SceneManager.LoadScene("MainMenu");
    }
    
    public void Settings()
    {
      SceneManager.LoadScene("Settings");
    }

    public void Return()
    {
      SceneManager.LoadScene("MainMenu");
    }
}
