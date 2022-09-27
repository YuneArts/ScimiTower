using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int gameStart;

    public AudioSource audio;

    public void playButton()
    {
      audio.Play();
    }

    public void StartGame() 
    {
      SceneManager.LoadScene("MapScene");
    }
}
