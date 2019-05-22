using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour {

    public GameObject objectToRepair;
    public GameObject particle;

    [SerializeField]
    private int neededPieces;
    [SerializeField]
    private float maxRepairTimer;
    private float repairTimer;

    private bool canRepair = false;
    public AudioClip audioClip;
    private AudioControler audioControler;

    private Player player;
    private PlayerMovementControler playerMovement;

    // Use this for initialization
    void Start () {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();
    }
	
	// Update is called once per frame
	void Update () {
        if (canRepair)
        {
            if (Input.GetAxisRaw("Interact") != 0)
            {
                repairTimer -= Time.deltaTime;
                repair();
            }
            else
            {
                repairTimer = maxRepairTimer;
                playerMovement.interruptMovement(false);
            }
        }
    }

    private void repair()
    {
        if(player.getRepairPiece() >= neededPieces)
        {
            playerMovement.interruptMovement(true);

            if (!audioControler.SFXisPlaying())
            {
                Instantiate(particle);
                audioControler.playSFX(audioClip);
            }

            if (repairTimer <= 0)
            {
                //Hard coded for Eleveator, TODO: Code for every object in Future
                objectToRepair.GetComponent<Elevator>().isRepaired = true;
                player.removeRepairPieces(neededPieces);
                canRepair = false;
                playerMovement.interruptMovement(false);
                repairTimer = maxRepairTimer;
            }
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
