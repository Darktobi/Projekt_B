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
    private string neededCode;
    private string enteredCode;
    private int maxCodeLength;
    private bool rightCodeEntered; 

	// Use this for initialization
	protected override void Start () {
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
        }

    }

    public void checkCode()
    {
        if(enteredCode == neededCode)
        {
            openCloseDoor();
            rightCodeEntered = true;
        }
        else
        {
            deleteCode();
        }

        disableKeyPad();
    }

    public void deleteCode()
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
