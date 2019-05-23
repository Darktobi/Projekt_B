using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Door {

    public Key.KeyColor neededKeyColor;

    private Player player;
    private bool canOpen = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        base.Start();
    }

    private void Update()
    {

        if (canOpen)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetAxisRaw("Interact") != 0)
            {
                check();
            }
        }
    }

    public override void check()
    {
        if (player.hasRightKey(neededKeyColor))
        {
            open();
        }
        else
        {
            block();
        }
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
        if (collision.gameObject.tag == "Player")
        {
            canOpen = false;
            FindObjectOfType<UIHandler>().disableUseInfo();
        }
    }
}
