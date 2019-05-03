using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;


	//variable nach wievielen Saetzen soll der Dialogue beendet sein. initalisiert auf 0
	private int kill = 0;
	//globale variable Quest Fortschritt
	public static int questprogress = 0;



	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();

	}

	public void StartDialogue (Dialogue dialogue)
	{
        Debug.Log("Test123");
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}




		if (questprogress == 1)
		{
		// ersten satz weglassen
		sentences.Dequeue();
		}




		DisplayNextSentence();



	}


	public void DisplayNextSentence ()
	{




		if (questprogress == 0)
		{
		//
		// zäheln wie oft aufgerufen dann stoppen. Kill wieder auf 0 setzen
		kill += 1;
		//Debug.Log (kill);
		//Debug.Log("Quest Fortschritt: "+questprogress);

		//nach einem Satz ist Schluss 4;
		if (kill == 2)
		{
			EndDialogue();
			return;
		}
		/////////
		}







		// beim berlassen kill auf 0 bringen
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
			


		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));



	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;

		//Text geschwindigkeit 4 frame pause
			yield return null;
		//	yield return null;
		//	yield return null;
		//	yield return null;



		}
	}

	/*
	// funktioniert noch nicht
	 void OnTriggerExit2D (Collider2D other) 
	{ 
		if (other.tag == "Player")
		{ 
			EndDialogue();

		}
	}
	*/

	public void EndDialogue()
	{
		kill = 0;
		animator.SetBool("IsOpen", false);
	}

}

// Debug.Log();