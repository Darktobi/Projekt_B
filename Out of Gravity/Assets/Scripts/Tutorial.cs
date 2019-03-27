using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "GravityChangerItem")
        {
            PlayerMovementControler playerMovement = FindObjectOfType<PlayerMovementControler>();
            playerMovement.activateGravityChanger();
            Destroy(gameObject);
        }
    }
}
