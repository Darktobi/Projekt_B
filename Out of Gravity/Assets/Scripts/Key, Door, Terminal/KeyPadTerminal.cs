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
    private float waitForCodeEnter = 0.2f;
    private bool rightCodeEntered;
    private bool keyPadActive;

	// Use this for initialization
	protected override void Start () {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementControler>();
        enteredCode = "";
        maxCodeLength = 4;
        rightCodeEntered = false;
        keyPadActive = false;
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

        if (keyPadActive)
        {

            if(Input.GetButtonDown("KeyPad_A"))
            {
                enterCode("A");
            }
           else if (Input.GetButtonDown("KeyPad_B"))
            {
                enterCode("B");
            }
           else if (Input.GetButtonDown("KeyPad_Y"))
            {
                enterCode("Y");
            }

            if (enteredCode.Length == maxCodeLength)
            {
                checkCode();
            }
        }
    }

    private void enterCode(string code)
    {
        enteredCode += code;
        codeText.text = "Code: " + enteredCode;
        audioControler.playSFX(buttonSound);
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
        keyPadActive = true;
        Time.timeScale = 0;
    }

    private void disableKeyPad()
    {
        keyPad.SetActive(false);
        keyPadActive = false;
        Time.timeScale = 1;
    }

    private void openCloseDoor()
    {
        door.OpenClose();
        changeSprite();
    }
}
