using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTerminal : Terminal {

    [SerializeField]
    protected Door openedDoor;

    [SerializeField]
    private LeverTerminal oppositeLever;
    [SerializeField]
    private AudioClip leverSound;
    private AudioControler audioControler;

    private PlayerMovementControler playerMovement;


    // Use this for initialization
   protected override void Start () {
        audioControler = GameObject.Find("SFX_Controler").GetComponent<AudioControler>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {

        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if(Input.GetButtonDown("Interact")){
                changeStatus();
                StartCoroutine(changeStatus());
            }
        }
	}

    IEnumerator changeStatus()
    {
        audioControler.playSFX(leverSound);
        playerMovement.interruptMovement(true);
        canUse = false;
        yield return new WaitForSeconds(0.5f);
        playerMovement.interruptMovement(false);
        door.OpenClose();
        openedDoor.OpenClose();
        changeSprite();
        oppositeLever.changeOppositeSprite();

        playerMovement.interruptMovement(false);
        canUse = true;

    }

    public void changeOppositeSprite()
    {
        changeSprite();
    }
}
