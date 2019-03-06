using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            checkForKey(player);
        }
    }

    private void checkForKey(Player player)
    {
        if(player.numOfKeys > 0)
        {
            player.removeKey();
            Destroy(gameObject);
        }

    }

}
