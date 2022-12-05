using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundAudio, sfxAudio;
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip mmMusic;

    [SerializeField]
    private SettimgsMenu settingsVol;
    
    void Start()
    {
      //Maybe get SettimgsMenu reference here.
        StartCoroutine(GrabSoundSettings());
    }

    void Update()
    {
      backgroundAudio.volume = SettimgsMenu.bgmVolume;
    }

    IEnumerator GrabSoundSettings()
    {
      if(!PlayerPrefs.HasKey("musicVolume"))
      {
        PlayerPrefs.SetFloat("musicVolume" , 0.5f);
        settingsVol.Load();
      }
      else
      {
        settingsVol.Load();
      }

      if(!PlayerPrefs.HasKey("sfxVolume"))
      {
        PlayerPrefs.SetFloat("sfxVolume" , 0.5f);
        settingsVol.Load();
      }
      else
      {
        settingsVol.Load();
      }

      if(!PlayerPrefs.HasKey("bgmVolume"))
      {
        PlayerPrefs.SetFloat("bgmVolume" , 0.5f);
        settingsVol.Load();
      }
      else
      {
        settingsVol.Load();
      }

      backgroundAudio = GetComponent<AudioSource>();
      sfxAudio = GetComponent<AudioSource>();

      yield return new WaitForSeconds(0.1f);

      backgroundAudio.clip = mmMusic;
      backgroundAudio.loop = true;
      backgroundAudio.Play();
    }
}
