using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    public float maxChangeTimer = 0.2f;

    private float changeTimer;
    private bool hasGravity;
    private bool gravityIsChanging;
    private float gravityScale = 9.8f;

	// Use this for initialization
	void Start () {
        Physics2D.gravity = new Vector2(0, -gravityScale);
        changeTimer = 0.2f;
        hasGravity = true;
        gravityIsChanging = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (gravityIsChanging)
        {
            changeGravityOverTime();
        } 
	}

    public void gravityOff()
    {
        Physics2D.gravity = new Vector2(0, 0);

        if (hasGravity)
        {
            hasGravity = false;
            gravityIsChanging = true;
        }
        
    }

    public void gravityOn()
    {
        Physics2D.gravity = new Vector2(0, -gravityScale);
        if (!hasGravity)
        {
            hasGravity = true;
            gravityIsChanging = true;
        }

    }

    private void changeGravityOverTime()
    {
        changeTimer -= Time.deltaTime;

        if (changeTimer <= 0)
        {
            if (!hasGravity)
            {
               
                gravityScale -= 4;
            }
            else
            {
                gravityScale += 4;
            }

            changeTimer = maxChangeTimer;
        }

        if (gravityScale < 0)
        {
            gravityScale = 0;
            gravityIsChanging = false;
        }
        else if (gravityScale > 9.8f)
        {
            gravityIsChanging = false;
            gravityScale = 9.8f;
        }

        Physics2D.gravity = new Vector2(0, -gravityScale);
    }
}
