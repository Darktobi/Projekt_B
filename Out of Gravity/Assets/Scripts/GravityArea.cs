using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityArea : MonoBehaviour {

    GameObject player;
    Vector2 middle;

    public float magnetism = 1.5f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = player.transform.position;
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "GravityObject")
        {
            middle = (transform.position - collision.transform.position).normalized;
            collision.GetComponent<Rigidbody2D>().velocity = middle * magnetism;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GravityObject")
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
