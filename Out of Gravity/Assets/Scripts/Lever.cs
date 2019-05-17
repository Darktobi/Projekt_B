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
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
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
            StartCoroutine(changeStatus());
            
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

    IEnumerator changeStatus()
    {
        audioControler.playSFX(audioClip);
        yield return new WaitForSeconds(0.5f);

        if (leverStatus)
        {
            audioControler.playSFX(GameObject.FindGameObjectWithTag("Vacuum").GetComponent<Vacuum>().audioClip);
            yield return new WaitForSeconds(1.2f);
            leverStatus = false;
            GameObject.FindGameObjectWithTag("Vacuum").transform.localScale = new Vector2(1, 1);
        }
        else
        {
            audioControler.playSFX(GameObject.FindGameObjectWithTag("Vacuum").GetComponent<Vacuum>().audioClip);
            yield return new WaitForSeconds(1.2f);
            leverStatus = true;
            GameObject.FindGameObjectWithTag("Vacuum").transform.localScale = new Vector2(2.5f, 1);
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
