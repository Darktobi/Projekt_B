using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            checkForKey(player);
        }
    }

    private void checkForKey(Player player)
    {
        if(player.hasKey)
        {
            Debug.Log("Schlüssel vorhanden!");
            player.removeKey();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Schlüssel nicht vorhanden!");
        }
    }

}
