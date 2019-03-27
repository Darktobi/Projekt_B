using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    public enum DoorColor { Red, Blue, Green };

    [SerializeField] private DoorColor color;

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

        if (player.keys.Count != 0)
        {
            if(color == DoorColor.Red)
            {
                if (player.hasRightKey(Key.KeyColor.Red))
                {
                    Destroy(gameObject);
                }
                
            }
            else if (color == DoorColor.Blue)
            {
                if(player.hasRightKey(Key.KeyColor.Blue))
                {
                    Destroy(gameObject);
                }
            }
            else if (color == DoorColor.Green)
            {
                if (player.hasRightKey(Key.KeyColor.Green))
                {
                    Destroy(gameObject);
                }
            }
            
        }

    }

}
