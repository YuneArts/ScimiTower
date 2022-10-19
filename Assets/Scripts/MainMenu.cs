using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

//Back() is for Credits button; Return() is for Settings button.


{
  [SerializeField] GameObject mainMenu, settings, credits;
  
  

    public int gameStart;

    public AudioSource mainmenuAudio;

    public void playButton()
    {
      mainmenuAudio.Play();
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
      mainMenu.SetActive(false);
      credits.SetActive(true);
    }
    
    public void Back()
    {
      mainMenu.SetActive(true);
      credits.SetActive(false);
      settings.SetActive(false);

    }
    
    public void Settings()
    {
      mainMenu.SetActive(false);
      settings.SetActive(true);
    }
}
