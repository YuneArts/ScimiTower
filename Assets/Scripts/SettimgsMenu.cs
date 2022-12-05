using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettimgsMenu : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;
     [SerializeField] Slider sfxSlider, bgmSlider;
     public static float SFXVOLUME;
     public static float bgmVolume;

   public void ChangeVolume()
   {
     AudioListener.volume = volumeSlider.value;
     SFXVOLUME=sfxSlider.value;
     bgmVolume = bgmSlider.value;
     Save();
   }

   public void Load()
   {
     volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
     sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
     bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0.5f);
   }

   public void Save()
   {
      PlayerPrefs.SetFloat("musicVolume" , volumeSlider.value);
      PlayerPrefs.SetFloat("sfxVolume" , volumeSlider.value);
      PlayerPrefs.SetFloat("bgmVolume" , volumeSlider.value);
   }
}