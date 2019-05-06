using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public enum KeyColor {Red, Blue, Green};
    public AudioClip clip;

    [SerializeField]private KeyColor color;

    private AudioControler audioControler;

    private void Start()
    {
        audioControler = GameObject.Find("Keys").GetComponent<AudioControler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.addKey(this);
            audioControler.playSFX(clip, 1, 0.9f);
            Destroy(gameObject);
        }
    }

    public KeyColor GetKeyColor()
    {
        return color;
    }

}
