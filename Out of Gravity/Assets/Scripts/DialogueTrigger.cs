using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

    private DialogueManager dialogueManager;
    private bool canOpenDialog;
    private float dialogTimer = 0;

    private void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (canOpenDialog)
        {
            if (Input.GetAxisRaw("Interact") != 0 && dialogTimer <= 0)
            {
                dialogueManager.DisplayNextSentence();
                dialogTimer = 0.5f;
            }

            if (dialogueManager.hasEndedDialogue)
            {
                dialogueManager.PrepareDialogue(dialogue);
            }
        }



        if(dialogTimer > 0)
        {
            dialogTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
	{
       
		if (collision.gameObject.tag == "Player")
        {
            canOpenDialog = true;
            dialogueManager.PrepareDialogue(dialogue);
        }
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
            canOpenDialog = false;
            dialogueManager.EndDialogue (); 
		}
	}


}
