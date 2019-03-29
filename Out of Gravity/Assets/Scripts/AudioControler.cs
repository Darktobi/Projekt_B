using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

    public bool destroyableObject;

    AudioSource backgroundMusic;
    AudioSource SFX;

    float volume = 1;
    float pitch = 1;

    private void Start()
    {
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        if (destroyableObject)
        {
            SFX = GameObject.Find("SFX_Controler").GetComponent<AudioSource>();
        }
        else
        {
            SFX = GetComponent<AudioSource>();
        }

    }

    public void playSFX(AudioClip clip)
    {
        resetSFX();

        SFX.PlayOneShot(clip);
    }

    public void playSFX(AudioClip clip, float volume, float pitch)
    {

        resetSFX();
        
        SFX.volume = volume;
        SFX.pitch = pitch;
        SFX.PlayOneShot(clip);
    }


    private void resetSFX()
    {
        SFX.volume = volume;
        SFX.pitch = pitch;
        SFX.Stop();
    }
}
