using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    public bool facingRight = true;
    public bool stuned;



    //GroundCheck
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;
    public bool grounded;

    //WallCheck

    public Transform wallCheck;
    public float wallCheckRadius = 0.2f;
    public LayerMask whatIsWall;
    public bool hitWall;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();	
        
	}
	
	void Update ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        if (!stuned) {
            if (!grounded || hitWall)
            //Flip!
            {
                Flip();
            }
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        speed = speed * -1;
        transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
    }


}
