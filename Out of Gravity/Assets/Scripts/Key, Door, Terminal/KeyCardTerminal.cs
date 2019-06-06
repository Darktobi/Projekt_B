using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardTerminal : Terminal {

    [SerializeField]
    private Key.KeyColor neededKeyColor;
    [SerializeField]
    private AudioClip insertKeyCard;
    private Player player;
    private PlayerMovementControler playerMovement;

    // Use this for initialization
    protected override void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {

        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetButtonDown("Interact"))
            {
                if (check())
                {
                    StartCoroutine(activate());
                }
            }

        }
    }

    IEnumerator activate()
    {
        audioControler.playSFX(insertKeyCard);
        playerMovement.interruptMovement(true);
        canUse = false;
        yield return new WaitForSeconds(0.5f);
        door.OpenClose();
        changeSprite();
        playerMovement.interruptMovement(false);
        canUse = true;
    }

    private bool check()
    {
        if (player.hasRightKey(neededKeyColor))
        {
            return true;
        }
            return false;
    }
}
