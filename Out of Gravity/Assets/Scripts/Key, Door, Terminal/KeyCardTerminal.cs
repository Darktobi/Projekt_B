using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardTerminal : Terminal {

    [SerializeField]
    private Key.KeyColor neededKeyColor;
    private Player player;

    // Use this for initialization
    protected override void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {

        if (canUse)
        {
            FindObjectOfType<UIHandler>().showUseInfo();

            if (Input.GetButtonDown("Interact"))
            {
                if (check())
                {
                    door.OpenClose();
                    changeSprite();
                }
            }

        }
    }

    private bool check()
    {
        if (player.hasRightKey(neededKeyColor))
        {
            return true;
        }
            return false;
    }
}
