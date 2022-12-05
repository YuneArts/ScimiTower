using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    [SerializeField]
    private GameObject resumeButton, settingsButton, mainmenuButton, options;
    public bool isPaused;
    [SerializeField]
    private SettimgsMenu volSettings;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        StartCoroutine(GetSoundSettings());
    }

    IEnumerator GetSoundSettings()
    {
      if(!PlayerPrefs.HasKey("musicVolume"))
      {
        PlayerPrefs.SetFloat("musicVolume" , 0.5f);
        volSettings.Load();
      }
      else
      {
        volSettings.Load();
      }
      yield return null;
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

    public void OpenPauseSettings()
    {
        resumeButton.SetActive(false);
        settingsButton.SetActive(false);
        mainmenuButton.SetActive(false);
        options.SetActive(true);
    }

    public void ExitPauseSettings()
    {
        resumeButton.SetActive(true);
        settingsButton.SetActive(true);
        mainmenuButton.SetActive(true);
        options.SetActive(false);
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
