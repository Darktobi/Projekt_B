using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Terminal : MonoBehaviour {

    [SerializeField]
    protected Door door;
    protected bool canUse;

	// Use this for initialization
	void Start () {
        canUse = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canUse = false;
            FindObjectOfType<UIHandler>().disableUseInfo();
        }
    }
}
