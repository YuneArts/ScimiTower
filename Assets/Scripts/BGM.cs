using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource bgm;
    [SerializeField]
    private AudioClip battleMusic, victoryMusic;
    // Start is called before the first frame update
    void Start()
    {
        bgm.volume = SettimgsMenu.bgmVolume;
        //PlayBGM();
    }

    void Update()
    {
        bgm.volume = SettimgsMenu.bgmVolume;
    }

    public void PlayBGM()
    {
        bgm.clip = battleMusic;
        bgm.pitch = 0.7f;
        bgm.loop = true;
        bgm.Play();
    }

    public void VictoryMusic()
    {
        bgm.clip = victoryMusic;
        bgm.pitch = 1f;
        bgm.loop = true;
        bgm.Play();
    }
}
