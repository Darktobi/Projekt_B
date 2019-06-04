using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour {

    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private Door neededOpenDoor;

	
	// Update is called once per frame
	void Update () {

        if (neededOpenDoor.isOpen)
        {
            transform.localScale = new Vector2(2.5f, 1);
        }

        else
        {
            transform.localScale = new Vector2(1, 1);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0f;

        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isInVaccum = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1f;

        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isInVaccum = false;
        }
        
    }
}
