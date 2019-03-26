using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
    public void idle()
    {
        anim.SetBool("is walking", false);
        
    }

    public void walkingRight()
    {
        anim.SetBool("is walking", true);
    }

    public void walkingLeft()
    {
        anim.SetBool("is walking", true);
    }

    public void floatingIdle()
    {
        //Change this when there is an Animation for no gravity
        anim.SetBool("is walking", false);
    }

    public void floatingRight()
    {
        //Change this when there is an Animation for no gravity
        anim.SetBool("is walking", false);
    }

    public void floatingLeft()
    {
        //Change this when there is an Animation for no gravity
        anim.SetBool("is walking", false);
    }

    public void jump()
    {
        anim.SetBool("has jumped", true);
    }

    public void jumpIdle()
    {
        anim.SetBool("has jumped", false);
    }

}
