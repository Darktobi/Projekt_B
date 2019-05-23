using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private static bool leverStatus = false;
    private static bool canOpen = false;
    private static GameObject[] leverDoors;

    public AudioClip audioClip;
    private AudioControler audioControler;

    private GameObject vacuum;
    private PlayerMovementControler playerMovement;

    private void Start()
    {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
        leverDoors = GameObject.FindGameObjectsWithTag("Lever-Door");
        vacuum = GameObject.FindGameObjectWithTag("Vacuum");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();

    }

    private void Update()
    {
        checkDoors();

        if( canOpen)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetAxisRaw("Interact") != 0)
          {
            changeStatus();
            StartCoroutine(changeStatus());
            
          }
        }
       
    }

    private void checkDoors()
    {
        foreach(GameObject g in leverDoors)
        {
            if (g.GetComponent<LeverDoor>().neededLeverStatus == leverStatus)
            {
                g.SetActive(false);
            }
            else {
                g.SetActive(true);
            }
        }
    }

    IEnumerator changeStatus()
    {
        audioControler.playSFX(audioClip);
        playerMovement.interruptMovement(true);
        canOpen = false;
        yield return new WaitForSeconds(0.5f);
        audioControler.playSFX(vacuum.GetComponent<Vacuum>().audioClip);
        yield return new WaitForSeconds(1.2f);

        if (leverStatus)
        {
            leverStatus = false;
            vacuum.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            leverStatus = true;
            vacuum.transform.localScale = new Vector2(2.5f, 1);
        }

        playerMovement.interruptMovement(false);
        canOpen = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canOpen = false;
            FindObjectOfType<UIHandler>().disableUseInfo();
        }
    }
}
