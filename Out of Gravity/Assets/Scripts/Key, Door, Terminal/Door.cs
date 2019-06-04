using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public AudioClip doorOpen;
    public bool isOpen;

    private AudioControler audioControler;

    protected void Start()
    {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
    }

    public void OpenClose()
    {
        if (!isOpen)
        {
            open();
        }
        else
        {
            close();
        }
    }


    private void open()
    {
        audioControler.playSFX(doorOpen);
        gameObject.SetActive(false);
        isOpen = true;
    }

    private void close()
    {
        gameObject.SetActive(true);
        isOpen = false;
    }
}
