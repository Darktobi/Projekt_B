using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Key.KeyColor neededKeyColor;
    public AudioClip audioClip;


    private AudioControler audioControler;

    private void Start()
    {
        audioControler = GameObject.Find("Door").GetComponent<AudioControler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            checkForKey(player);
            
        }
    }

    private void checkForKey(Player player)
    {

        if (player.hasRightKey(neededKeyColor))
        {
          audioControler.playSFX(audioClip);
          Destroy(gameObject);
        }

    }

}
