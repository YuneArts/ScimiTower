using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettimgsMenu : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;
     [SerializeField] Slider sfxSlider;
     public static float SFXVOLUME;
    


    /*
    // Start is called before the first frame update
    void Start()
    {
      if(!PlayerPrefs.HasKey("musicVolume"))
      {
        PlayerPrefs.SetFloat("musicVolume" , 0.5f);
        Load();
      }
      else
      {
        Load();
      }
    }
    */

   public void ChangeVolume()
   {
     AudioListener.volume = volumeSlider.value;
     SFXVOLUME=sfxSlider.value;
     Save();
   }

   public void Load()
   {
     volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
     sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
   }

   public void Save()
   {
    PlayerPrefs.SetFloat("musicVolume" , volumeSlider.value);
    PlayerPrefs.SetFloat("sfxVolume" , volumeSlider.value);
   }
}