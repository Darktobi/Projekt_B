using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Laufen und Springen erklären
        if(gameObject.name == "StartTutorial")
        {
            Debug.Log("Laufen mithilfe der Pfeilstasten Links und Rechts. Springen mithilfe der Space-Taste");
            Destroy(gameObject);
        }

        else if (gameObject.name == "GravityTutorial")
        {
            Debug.Log("E gedrückt halten für das Ausschalten der Schwerkraft");
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.hasGravityChanger = true;
            Destroy(gameObject);
        }
    }
}
