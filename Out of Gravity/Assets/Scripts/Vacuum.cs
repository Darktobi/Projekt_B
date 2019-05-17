using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour {

    public AudioClip audioClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
