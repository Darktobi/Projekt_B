using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour {

    public float maxSpeed = 10;
    public float speedReduceFactor = 2.5f;
    public float jumpForce = 350f;
    public float groundedDistToGround;
    public float stairsDistToGround;
    public PhysicsMaterial2D bounce;
    public LayerMask groundLayer;

    private float speed;
    private bool hasGravityArea = false;
    private float distToGround;
    private Rigidbody2D rbody;
    private BoxCollider2D colider;
    private SpriteRenderer spriteRenderer;
    private PlayerAnimationControler animationControler;
    private Player player;
    private GravityChanger gravityChanger;


    void Start () {
        speed = maxSpeed;
        distToGround = groundedDistToGround;
        rbody = GetComponent<Rigidbody2D>();
        colider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        animationControler = GetComponent<PlayerAnimationControler>();
        gravityChanger = GameObject.Find("GravityChanger").GetComponent<GravityChanger>();
    }

	void FixedUpdate () {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float gravityAxis = Input.GetAxisRaw("GravityChange");
        float jumpAxis = Input.GetAxisRaw("Jump");
        float speedAxis = Input.GetAxisRaw("SpeedUp");

        if (x < 0)
        {
            flipSprite(true); 
        }
        else if (x > 0)
        {
            flipSprite(false);
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

        Vector2 dir = new Vector2(x * speed, rbody.velocity.y);

        //Movement for Jumping
        if (jumpAxis != 0 && isGrounded())
        {
            jump(x);
        }
        //Movement if Not jumping
        else if(isGrounded())
        {
            animationControler.idle();
            if (dir.x != 0)
            {
                animationControler.walking();
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
            animationControler.jump();
            rbody.AddForce(new Vector2(0, jumpForce));  
    }

    private void flipSprite(bool flip)
    {

        if (flip && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
            colider.offset = new Vector2(colider.offset.x * -1, colider.offset.y); 
            //prevent stucking in walls
            rbody.position = new Vector2(rbody.position.x - 0.5f, rbody.position.y);
        }
        else if (!flip && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
            colider.offset = new Vector2(colider.offset.x * -1, colider.offset.y);
            //prevent stucking in walls
            rbody.position = new Vector2(rbody.position.x + 0.5f, rbody.position.y);
        }
    }

    private bool isGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distToGround, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            distToGround = stairsDistToGround;
            Debug.Log("Test");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            distToGround = groundedDistToGround;
        }
    }
}
