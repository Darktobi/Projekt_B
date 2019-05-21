using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

    AudioSource backgroundMusic;
    AudioSource SFX;

    float volume = 1;
    float pitch = 1;

    private void Start()
    {
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        SFX = GetComponent<AudioSource>();
       
    }

    public void playBackgroundMusic(AudioClip clip)
    {
        resetBackgroundMusic();
        backgroundMusic.clip = clip;
        backgroundMusic.Play();
    }

    public void playBackgroundMusic(AudioClip clip, float volume, float pitch)
    {
        resetBackgroundMusic();

        backgroundMusic.clip = clip;
        backgroundMusic.volume = volume;
        backgroundMusic.pitch = pitch;
        backgroundMusic.Play();
    }

    public void stopBackgroundMusic()
    {
        backgroundMusic.Stop();
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

    public void playSFXLoop(AudioClip clip, float volume, float pitch)
    {
        resetSFX();

        SFX.volume = volume;
        SFX.pitch = pitch;
        SFX.loop = true;
        SFX.clip = clip;
        SFX.Play();
    }

    public void stopSFX()
    {
        SFX.Stop();
    }

    public bool SFXisPlaying()
    {
        return SFX.isPlaying;
    }

    private void resetBackgroundMusic()
    {
        backgroundMusic.volume = volume;
        backgroundMusic.pitch = pitch;
        backgroundMusic.loop = true;
        backgroundMusic.Stop();
    }


    private void resetSFX()
    {
        SFX.volume = volume;
        SFX.pitch = pitch;
        SFX.loop = false;
        SFX.Stop();
    }
}
