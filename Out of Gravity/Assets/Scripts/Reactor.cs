using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour {

    public GameObject objectToRepair;
    public GameObject particle;

    [SerializeField]
    private int neededPieces;

    private bool canRepair = false;
    public AudioClip audioClip;
    private AudioControler audioControler;

    private Player player;

    // Use this for initialization
    void Start () {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (canRepair)
        {
            if (Input.GetAxisRaw("Interact") != 0)
            {
                repair();
            }
        }
    }

    private void repair()
    {
        //Hard coded for Eleveator, TODO: Code for every object in Future
        if(player.getRepairPiece() >= neededPieces)
        {
            Instantiate(particle);
            objectToRepair.GetComponent<Elevator>().isRepaired = true;
            audioControler.playSFX(audioClip);
            player.removeRepairPieces(neededPieces);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canRepair = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canRepair = false;
        }
    }
}
