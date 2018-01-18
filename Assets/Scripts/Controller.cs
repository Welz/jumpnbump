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
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("jump trigger");

        }
        //left side walking
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isWalking", true);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-0.01f, 0f, 0f);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }
        //right side walking
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(-1*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(0.01f, 0f, 0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
