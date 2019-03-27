using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 350f;
    public GravityChanger gravityChanger;

    private bool hasGravityChanger;
    private bool isGrounded = true;

    Rigidbody2D rbody;
    PlayerAnimationControler animationControler;


    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        animationControler = GetComponent<PlayerAnimationControler>();
        //For testing
        hasGravityChanger = false;
    }

	void FixedUpdate () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float gravityAxis = Input.GetAxisRaw("GravityChange");
        float jumpAxis = Input.GetAxisRaw("Jump");
        float speedAxis = Input.GetAxisRaw("SpeedUp");

        if (hasGravityChanger)
        {
            //Turn gravity off
            // TODO: Load Battery only, if button is released
            if (gravityAxis != 0 && !gravityChanger.batteryIsEmpty())
            {
                gravityChanger.gravityOff();
                gravityOffMovement(x, y);
            }
            //Turn gravity on
            else
            {
                gravityChanger.gravityOn();
                gravityOnMovement(x, jumpAxis);
            }
        }
        else
        {
            gravityChanger.gravityOn();
            gravityOnMovement(x, jumpAxis);
        }

    }

    public void activateGravityChanger()
    {
        hasGravityChanger = true;
    }

    private void gravityOnMovement(float x, float jumpAxis)
    {
        if (jumpAxis != 0)
        {
            jump(x);
        }

        Vector2 dir = new Vector2(x * speed, rbody.velocity.y);

        //Animation for walking only, when player is on ground
        if (isGrounded)
        {
            if (dir.x != 0)
            {
                animationControler.walkingRight();
            }
            else
            {
                animationControler.idle();
            }
        }

        rbody.velocity = dir;
    }

    private void gravityOffMovement(float x, float y)
    {

        animationControler.floatingIdle();

        Vector2 dir = new Vector2(x * (speed / 2), y * (speed / 2));
        rbody.AddForce(dir);

        if (rbody.velocity.magnitude > speed)
        {
            rbody.velocity = rbody.velocity.normalized * speed;
        }
    }

    private void jump(float x)
    {
        if (isGrounded)
        {
            animationControler.jump();
            rbody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            isGrounded = true;
            animationControler.jumpIdle();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            isGrounded = false;
        }
    }
}
