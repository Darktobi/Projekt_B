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
        if (canRepair && player.getRepairPiece() >= neededPieces)
        {
            FindObjectOfType<UIHandler>().showUseInfo();
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
     
        playerMovement.interruptMovement(true);

         if (!audioControler.SFXisPlaying())
          {
            Instantiate(particle);
             audioControler.playSFX(audioClip);
          }

          if (repairTimer <= 0)
          {
             objectToRepair.gameObject.SetActive(true);
             player.removeRepairPieces(neededPieces);
             playerMovement.interruptMovement(false);
             repairTimer = maxRepairTimer;
             FindObjectOfType<UIHandler>().disableUseInfo();
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
