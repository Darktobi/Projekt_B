using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public Vector2 teleportPoint;

    private bool canUse = false;

    private GameObject player;
    private PlayerMovementControler playerMovement;

    public AudioClip audioClip;
    private AudioControler audioControler;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovementControler>();
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();

    }

    // Update is called once per frame
    void Update () {
        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetAxisRaw("Interact") != 0)
            {
                canUse = false;
                StartCoroutine(teleport());
            }
        }
	}

    IEnumerator teleport()
    {
        audioControler.playSFX(audioClip);
        playerMovement.interruptMovement(true);
        yield return new WaitForSeconds(0.7f);
        player.transform.position = teleportPoint;
        playerMovement.interruptMovement(false);
        
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
            FindObjectOfType<UIHandler>().disableUseInfo();
        }
    }
}
