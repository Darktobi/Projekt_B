using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour {

    public bool neededLeverStatus;
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(true);
	}
}
