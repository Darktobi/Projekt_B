using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

    public bool hasEndedDialogue;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        hasEndedDialogue = false;
		sentences = new Queue<string>();
	}

	public void PrepareDialogue (Dialogue dialogue)
	{
        hasEndedDialogue = false;
        nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
	}

	public void DisplayNextSentence ()
	{
        animator.SetBool("IsOpen", true);
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
        dialogueText.text = sentence;

        /*
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;

		//Text geschwindigkeit 4 frame pause
			

		}
        */

        yield return null;
    }

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
        hasEndedDialogue = true;
}

}
