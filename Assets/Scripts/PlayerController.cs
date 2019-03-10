using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    private Rigidbody2D rigidbody2D;
    private bool facingRinght = false;
    private bool jump = false;
    private Animator animator;
    private bool notFloor = false;
    private Transform groundCheck;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GoundCheck");

    }

    // Update is called once per frame
    void Update()
    {
        notFloor = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButton("Jump") && notFloor)
        {
            jump = true;
            animator.SetTrigger("Jump");
        }

    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Walk", Math.Abs(h));
        rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
        if (h > 0 && facingRinght)
        {
            Flip();
        }
        else if (h < 0 && !facingRinght)
        {
            Flip();
        }
        if (jump)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    void Flip()
    {
        facingRinght = !facingRinght;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
   
}
