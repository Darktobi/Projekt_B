using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    public float maxJumpTimer = 1f;
    private float jumpTimer;
    public GravityChanger gravityChanger;

    private bool hasJumped = false;

    Rigidbody2D rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        jumpTimer = maxJumpTimer;
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        if (hasJumped)
        {
            jumpTimer -= Time.deltaTime;
            if(jumpTimer <= 0)
            {
                hasJumped = false;
                jumpTimer = 1f;
            }
        }  
	}

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (gravityChanger.gravityIsOn())
        {
            if (!gravityChanger.checkGravityIsChanging())
            {
                gravityOnMovement(x);
            }        
        }
        else
        {
            gravityOffMovement(x, y);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityChanger.changeGravity();
        }

        if (Input.GetKey(KeyCode.V))
        {
            if (speed < 20)
            {
                speed *= 2;
            }
        }

        else if (Input.GetKeyUp(KeyCode.V))
        {
            speed = speed / 2;
        }

    }

    private void gravityOnMovement(float x)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump(x);     
        }

        Vector2 dir = new Vector2(x * speed, rbody.velocity.y);
        rbody.velocity = dir;
    }

    private void gravityOffMovement(float x, float y)
    {
        Vector2 dir = new Vector2(x * (speed / 2), y * (speed / 2));
        rbody.AddForce(dir);

        if (rbody.velocity.magnitude > speed)
        {
            rbody.velocity = rbody.velocity.normalized * speed;
        }
    }

    private void jump(float x)
    {
        if (!hasJumped)
        {    
            rbody.AddForce(new Vector2(0, 250f));
            rbody.velocity = new Vector2(x * speed, rbody.velocity.y);
            hasJumped = true;
        }
    }

}
