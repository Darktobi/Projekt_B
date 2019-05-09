﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private static bool leverStatus = false;
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F)){
                changeStatus();
                audioControler.playSFX(audioClip);
            }
            
        }
    }
}