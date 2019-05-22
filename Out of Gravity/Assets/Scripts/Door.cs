using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour {

    public AudioClip doorOpen;
    public AudioClip doorBlock;
    private AudioControler audioControler;

    protected void Start()
    {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
    }

    protected void open()
    {
        audioControler.playSFX(doorOpen);
        Destroy(gameObject);
    }

    protected void block()
    {
        if (!audioControler.SFXisPlaying())
        {
            audioControler.playSFX(doorBlock);
        }
        
    }

    public abstract void check();



}
