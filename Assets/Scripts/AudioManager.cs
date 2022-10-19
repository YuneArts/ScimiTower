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
        StartCoroutine(GrabSoundSettings());
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

      backgroundAudio = GetComponent<AudioSource>();
      sfxAudio = GetComponent<AudioSource>();

      yield return new WaitForSeconds(0.1f);

      backgroundAudio.clip = mmMusic;
      backgroundAudio.loop = true;
      backgroundAudio.Play();
    }
}
