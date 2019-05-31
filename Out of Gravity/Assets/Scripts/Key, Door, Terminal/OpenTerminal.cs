using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTerminal : Terminal {

	void Update () {

        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetButtonDown("Interact"))
            {
                door.OpenClose();
                changeSprite();
            }

        }
    }
}
