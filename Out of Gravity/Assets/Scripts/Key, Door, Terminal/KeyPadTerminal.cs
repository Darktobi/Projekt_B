using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyPadTerminal : Terminal {

    public Text codeText;

    [SerializeField]
    private GameObject keyPad;
    [SerializeField]
    private GameObject highlightedButton;
    [SerializeField]
    private AudioClip buttonSound;
    [SerializeField]
    private AudioClip CodeSucess;
    [SerializeField]
    private AudioClip CodeWrong;
    [SerializeField]
    private string neededCode;

    private PlayerMovementControler playerMovement;
    private string enteredCode;
    private int maxCodeLength;
    private bool rightCodeEntered; 

	// Use this for initialization
	protected override void Start () {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();
        enteredCode = "";
        maxCodeLength = 4;
        rightCodeEntered = false;
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {

        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetButtonDown("Interact"))
            {
                if (!rightCodeEntered)
                {
                    activateKeyPad();
                }
                else
                {
                    openCloseDoor();
                }
            }

        }
    }

    public void enterCode(string code)
    {
        if(enteredCode.Length < maxCodeLength)
        {
            enteredCode += code;
            codeText.text = "Code: " + enteredCode;
            audioControler.playSFX(buttonSound);
        }

    }

    public void checkCode()
    {
        if(enteredCode == neededCode)
        {
            StartCoroutine(activate());
            rightCodeEntered = true;
        }
        else
        {
            audioControler.playSFX(CodeWrong);
            deleteCode();
        }

        disableKeyPad();
    }

    public void pressDeleteCode()
    {
        audioControler.playSFX(buttonSound);
        deleteCode();
    }

    IEnumerator activate()
    {
        audioControler.playSFX(CodeSucess);
        playerMovement.interruptMovement(true);
        canUse = false;
        yield return new WaitForSeconds(0.6f);
        openCloseDoor();
        playerMovement.interruptMovement(false);
        canUse = true;
       
    }

    private void deleteCode()
    {
        enteredCode = "";
        codeText.text = "Code:";
    }

    private void activateKeyPad()
    {
        keyPad.SetActive(true);
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(highlightedButton);
    }

    private void disableKeyPad()
    {
        keyPad.SetActive(false);
        Time.timeScale = 1;
    }

    private void openCloseDoor()
    {
        door.OpenClose();
        changeSprite();
    }
}
