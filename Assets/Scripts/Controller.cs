using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Animator animator;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //jumping
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isJumping",true);

        }else
        {
            animator.SetBool("isJumping", false);
        }

        //left side walking
        if(Input.GetKey(KeyCode.A))
        {
            //Change sprite direction if needed
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("isWalking", true);
            transform.localPosition -= new Vector3(0.05f, 0f, 0f);
        }

        //right side walking
        if (Input.GetKey(KeyCode.D))
        {
            //Change sprite direction if needed
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            animator.SetBool("isWalking", true);
            transform.localPosition += new Vector3(0.05f, 0f, 0f);
        }

        //stop walking
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }

    }
}
