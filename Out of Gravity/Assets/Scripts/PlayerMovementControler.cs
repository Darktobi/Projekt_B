using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour {

    public float maxSpeed = 10;
    public float speedReduceFactor = 2.5f;
    public float jumpForce = 350f;
    public PhysicsMaterial2D bounce;

    private float speed;
    private bool isGrounded = true;
    private bool hasGravityArea = false;
    private Rigidbody2D rbody;
    private PlayerAnimationControler animationControler;
    private Player player;
    private GravityChanger gravityChanger;


    void Start () {
        speed = maxSpeed;
        rbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        animationControler = GetComponent<PlayerAnimationControler>();
        gravityChanger = GameObject.Find("GravityChanger").GetComponent<GravityChanger>();
    //For testing
    }

	void FixedUpdate () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float gravityAxis = Input.GetAxisRaw("GravityChange");
        float jumpAxis = Input.GetAxisRaw("Jump");
        float speedAxis = Input.GetAxisRaw("SpeedUp");

        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (player.hasGravityChanger)
        {
            //Turn gravity off
            // TODO: Load Battery only, if button is released
            if (gravityAxis != 0 && !gravityChanger.batteryIsEmpty())
            {
                gravityChanger.turnOn();
                gravityChangerOnMovement(x, y);
            }
            //Turn gravity on
            else
            {
                gravityChanger.turnOff();
                gravityChangerOffMovement(x, jumpAxis);
            }
        }
        else
        {
            gravityChanger.turnOff();
            gravityChangerOffMovement(x, jumpAxis);
        }

    }

    private void gravityChangerOffMovement(float x, float jumpAxis)
    {
        rbody.sharedMaterial = null;
        speed = maxSpeed;

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

    private void gravityChangerOnMovement(float x, float y)
    {
        rbody.sharedMaterial = bounce;
        animationControler.floatingIdle();
        speed = maxSpeed / speedReduceFactor;

        Vector2 dir = new Vector2(x * speed, y * speed);

        if (x != 0 || y != 0)
        {
            gravityChanger.Moving(true);
            rbody.AddForce(dir);
        }
        else
        {
            gravityChanger.Moving(false);
            rbody.AddForce(-rbody.velocity * 1.5f);
        }

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
