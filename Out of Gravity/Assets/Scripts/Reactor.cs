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

    private bool canUse = false;
    private bool isRepaired = false;
    public AudioClip audioClip;
    public AudioClip NoUse;
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

        if (!isRepaired && canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (player.getRepairPiece() >= neededPieces)
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
                    FindObjectOfType<UIHandler>().disableRepairBar();
                }
            }

            else if (Input.GetAxisRaw("Interact") != 0)
            {
                
                if (!audioControler.SFXisPlaying())
                {
                    audioControler.playSFX(NoUse);
                }
            }
        }
    }
       

    private void repair()
    {
        FindObjectOfType<UIHandler>().disableUseInfo();
        FindObjectOfType<UIHandler>().showRepairBar(maxRepairTimer, repairTimer);

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
             isRepaired = true;
             FindObjectOfType<UIHandler>().disableUseInfo();
             FindObjectOfType<UIHandler>().disableRepairBar();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canUse = true;
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
