using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour {

    public AudioClip audioClip;
    private AudioControler audioControler;

    private void Start()
    {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            check(player);
        }
    }

    protected void open()
    {
        audioControler.playSFX(audioClip);
        Destroy(gameObject);
    }

    public abstract void check(Player player);



}
