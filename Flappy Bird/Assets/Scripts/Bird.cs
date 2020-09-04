using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private bool isDead = false; //Has the player collided with a wall?
    Rigidbody2D rb2d; //Holds a reference to the Rigidbody2D component of the bird
    Animator anim; //Reference to the Animator component.

    public float upForce = 200.0f; //Upward force of the "flap".

    // Start is called before the first frame update
    void Start()
    {
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();

        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0))
            {
                //pag cinlick ng cinlick yung mouse, tatalong ng tatalong pabilis ng pabilis yung bird, parang nag bubuild up yung pagtalong ni bird
                rb2d.velocity = Vector2.zero; //pataas at pababa lang naman si bird

                //    new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0.0f, upForce));

                //...tell the animator about it and then...
                anim.SetTrigger("Flap");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bird collides with something set it to dead...
        isDead = true;
        rb2d.velocity = Vector2.zero;
        //...tell the Animator about it...
        anim.SetTrigger("Dead");
        GameControl.instance.BirdDied();
    }
}
