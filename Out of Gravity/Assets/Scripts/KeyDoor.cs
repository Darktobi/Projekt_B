using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : Door {

    public Key.KeyColor neededKeyColor;

    public override void check(Player player)
    {
        if (player.hasRightKey(neededKeyColor))
        {
            open();
        }

    }
}
