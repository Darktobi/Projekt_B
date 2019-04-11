using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 350f;
    public PhysicsMaterial2D bounce;
    public GameObject gravityArea;

    private bool isGrounded = true;
    private bool hasGravityArea = false;
    private Rigidbody2D rbody;
    private PlayerAnimationControler animationControler;
    private Player player;
    private GravityChanger gravityChanger;


    void Start () {
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

        if (player.hasGravityChanger)
        {
            //Turn gravity off
            // TODO: Load Battery only, if button is released
            if (gravityAxis != 0 && !gravityChanger.batteryIsEmpty())
            {
                setGravityArea();
                gravityChanger.gravityOff();
                gravityOffMovement(x, y);
            }
            //Turn gravity on
            else
            {
                destroyGravityArea();
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

    private void gravityOnMovement(float x, float jumpAxis)
    {
        rbody.sharedMaterial = null;
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
        rbody.sharedMaterial = bounce;
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

    private void setGravityArea()
    {
        if (!hasGravityArea)
        {
            Instantiate(gravityArea, this.gameObject.transform.position, Quaternion.identity);
            hasGravityArea = true;
        }
    }

    private void destroyGravityArea()
    {
        Destroy(GameObject.FindGameObjectWithTag("GravityArea"));
        hasGravityArea = false;
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
