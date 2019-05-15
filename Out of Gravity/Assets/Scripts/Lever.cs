using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private static bool leverStatus = false;
    private static bool canOpen = false;
    private static GameObject[] gameobjects;

    public AudioClip audioClip;
    private AudioControler audioControler;

    private void Start()
    {
        audioControler = GameObject.Find("Doors").GetComponent<AudioControler>();
        gameobjects = GameObject.FindGameObjectsWithTag("Lever-Door");

    }

    private void Update()
    {
        checkDoors();

        if( canOpen)
        {
             if (Input.GetKeyDown(KeyCode.F))
        {
            changeStatus();
            audioControler.playSFX(audioClip);
        }
        }
       
    }

    private void checkDoors()
    {
        foreach(GameObject g in gameobjects)
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

    private void changeStatus()
    {
        if (leverStatus)
        {
            leverStatus = false;
        }
        else
        {
            leverStatus = true;
        }
        canOpen = false;
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
        }
    }
}
