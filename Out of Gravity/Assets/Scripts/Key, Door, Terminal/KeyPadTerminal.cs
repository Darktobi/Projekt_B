using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadTerminal : Terminal {

    [SerializeField]
    private GameObject keyPad;

    [SerializeField]
    private string neededCode;
    private string enteredCode;
    private bool rightCodeEntered; 

	// Use this for initialization
	protected override void Start () {
        enteredCode = "";
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
        enteredCode += code;
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
    }

    private void activateKeyPad()
    {
        keyPad.SetActive(true);
    }

    private void disableKeyPad()
    {
        keyPad.SetActive(false);
    }

    private void openCloseDoor()
    {
        door.OpenClose();
        changeSprite();
    }
}
