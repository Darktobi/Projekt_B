using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDoor : Door {

    public string neededCode;

    public override void check()
    {
        /*
        if (player.hasRightDoorCode(neededCode))
        {
            open();
        }

        else
        {
            Debug.Log("Folgender Code benötigt: " + neededCode);
        }
        */
    }
}

