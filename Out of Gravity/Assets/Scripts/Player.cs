using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10;
    public float jumpForce = 350f;
    public GravityChanger gravityChanger;
    //Prototype Lösung
    public int numOfKeys = 0;

    private bool isGrounded = true;
    

    Rigidbody2D rbody;
    Animator anim;

	// Use this for initialization
	void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void addKey()
    {
        numOfKeys++;
    }

    public void removeKey()
    {
        numOfKeys--;
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float gravityAxis = Input.GetAxisRaw("GravityChange");
        float jumpAxis = Input.GetAxisRaw("Jump");
        float speedAxis = Input.GetAxisRaw("SpeedUp");


        //Schwerkraft ausschalten
        if (gravityAxis != 0)
        {
            gravityChanger.gravityOff();
            gravityOffMovement(x, y);
        }
        //Schwerkraft wieder einschalten
        else
        {
            gravityChanger.gravityOn();
            gravityOnMovement(x, jumpAxis);
        }

    }

    private void gravityOnMovement(float x, float jumpAxis)
    {
        if (jumpAxis!=0)
        {
            jump(x);     
        }

        Vector2 dir = new Vector2(x * speed, rbody.velocity.y);
        if(dir.x != 0)
        {

            anim.SetBool("is walking", true);
        }
        else
        {
            anim.SetBool("is walking", false);
        }
        rbody.velocity = dir;
    }

    private void gravityOffMovement(float x, float y)
    {
        anim.SetBool("is walking", false);
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
            anim.SetBool("has jumped", true);
            rbody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            isGrounded = true;
            anim.SetBool("has jumped", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            isGrounded = false;
        }
    }

}
