using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    Rigidbody2D rigidbody2d;
    bool facingRight = false;
    bool notFloor = false;
    Transform groundCheck;
    public float jumpForce = 700;
    
	void Start () {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");

	}
	
	// Update is called once per frame
	void Update () {
        notFloor = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!notFloor)
            speed *= -1;
	}
    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
        if(speed> 0&& !facingRight)
        {
            flip();
        }
        else if(speed <0 && facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x  *= -1;
        transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            speed = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject,3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().DeadPlayer();
        }
    }
}
