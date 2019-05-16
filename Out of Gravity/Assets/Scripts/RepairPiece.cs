using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPiece : MonoBehaviour {

    public AudioClip clip;

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
            player.addRepairPiece();
            audioControler.playSFX(clip, 1, 0.9f);
            Destroy(gameObject);
        }
    }
}
