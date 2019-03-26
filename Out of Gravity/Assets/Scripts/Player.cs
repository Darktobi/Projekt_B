using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Prototype Solution
    public int numOfKeys = 0;


	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

    }

    public void addKey()
    {
        numOfKeys++;
    }

    public void removeKey()
    {
        numOfKeys--;
    }
}
