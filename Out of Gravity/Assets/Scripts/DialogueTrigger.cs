using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {


	public Dialogue dialogue;



	void OnTriggerEnter2D(Collider2D other) 
	{
       
		if (other.tag == "Player")
        {
            Debug.Log("Dialog");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
		}
	}


	void OnTriggerExit2D(Collider2D other2)
	{
		

		if (other2.tag == "Player") {
			FindObjectOfType<DialogueManager> ().EndDialogue (); 
		}
	}


}
