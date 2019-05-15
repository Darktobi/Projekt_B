using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public Vector2 teleportPoint;

    private bool canUse = false;

    private GameObject player;

    public AudioClip audioClip;
    private AudioControler audioControler;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioControler = GameObject.Find("Doors").GetComponent<AudioControler>();

    }

    // Update is called once per frame
    void Update () {
        if (canUse)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                canUse = false;
                StartCoroutine(teleport());
            }
        }
	}

    IEnumerator teleport()
    {
        audioControler.playSFX(audioClip);
        player.GetComponent<PlayerMovementControler>().interruptMovement(true);
        yield return new WaitForSeconds(0.7f);
        player.transform.position = teleportPoint;
        player.GetComponent<PlayerMovementControler>().interruptMovement(false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = false;
        }
    }
}
