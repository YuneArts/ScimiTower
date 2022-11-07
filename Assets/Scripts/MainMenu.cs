using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

//Back() is for Credits button; Return() is for Settings button.


{
    [SerializeField] 
    private GameObject mainMenu, settings, credits, startGameOptions, gameModeButtons;
  
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
      startGameOptions.SetActive(true);
    }

    public void Credits()
    {
      mainMenu.SetActive(false);
      credits.SetActive(true);
      startGameOptions.SetActive(false);
    }
    
    public void Back()
    {
      mainMenu.SetActive(true);
      credits.SetActive(false);
      settings.SetActive(false);
      startGameOptions.SetActive(false);
    }
    
    public void Settings()
    {
      mainMenu.SetActive(false);
      settings.SetActive(true);
      startGameOptions.SetActive(false);
    }

    public void NewGame()
    {
      gameModeButtons.SetActive(true);
      startGameOptions.SetActive(false);
    }

    public void NewDescensionMode()
    {
      SceneManager.LoadScene("BattleScreen");
      //Reference the blank slate/new run information that the player should be starting out with upon starting a new run.
      DataHolder.Instance.StartDescensionMode();
    }

    public void NewAscensionMode()
    {
      SceneManager.LoadScene("AscensionBattle");
      DataHolder.Instance.StartAscensionMode();
    }

    public void ContinueGame()
    {
      if (DataHolder.Instance.currentIndex > 0)
      {
        if (DataHolder.Instance.descensionMode == true)
        {
          SceneManager.LoadScene("BattleScreen");
        }
        else if (DataHolder.Instance.ascensionMode == true)
        {
          SceneManager.LoadScene("AscensionBattle");
        }
      }
    }
}
