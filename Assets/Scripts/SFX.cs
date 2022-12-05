using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx.volume = SettimgsMenu.SFXVOLUME;
    }

    // Update is called once per frame
    void Update()
    {
        sfx.volume = SettimgsMenu.SFXVOLUME;
    }

    public void PlaySfx()
    {
        sfx.Play();
    }
}
