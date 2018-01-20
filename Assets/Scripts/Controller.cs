using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float jumpForce = 10.0f;
    public float movingForce = 5.0f;

    private Animator animator;
    private Rigidbody2D rb;
    public bool grounded = false; //change back to private
    

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocityY", rb.velocity.y);
        //jumping
        if (Input.GetKey(KeyCode.W) && grounded)
        {
            animator.SetBool("isGrounded",false);
            rb.velocity += new Vector2(0f, jumpForce);
        }else if (grounded)
        {
            animator.SetBool("isGrounded", true);
        }

        //left side walking
        if(Input.GetKey(KeyCode.A) && grounded)
        {
            //Change sprite direction if needed
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("isWalking", true);
            rb.position -= new Vector2(movingForce, 0f);
        }

        //right side walking
        if (Input.GetKey(KeyCode.D) && grounded)
        {
            //Change sprite direction if needed
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("isWalking", true);
            rb.position += new Vector2(movingForce, 0f);
        }

        //stop walking
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }

    }

    // This part detects whether or not the object is grounded and stores it in a variable.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TO DO: add tags to differentiate borders from ground.
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
