using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettimgsMenu : MonoBehaviour

{
    [SerializeField] Slider volumeSlider;
     [SerializeField] Slider sfxSlider;
     public static float SFXVOLUME;

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