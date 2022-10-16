using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameStart;

    public AudioSource mainmenuAudio;

    public void playButton()
    {
      mainmenuAudio.Play();
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
      SceneManager.LoadScene("BattleScreen");
    }
}
