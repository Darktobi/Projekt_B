using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoor : MonoBehaviour {

    [SerializeField]
    public bool neededLeverStatus;
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(true);
	}
}
