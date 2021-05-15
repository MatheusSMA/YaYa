using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]        //Animator,RigidBody,SpriteRenderer, STATUS
    [Space(2)]
    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public PlayerHealth ph;
    public Transform groundCheck;
    public Transform roofCheck;
    Vector2 move;
    public GameObject PlayerPlataformHead;
    [Space(5)]

    [Header("Player Speed")]            //All moviment things
    public float speed;
    public float crouchSpeed;
    protected float hMove;
    protected float speedFix = 8.2f;
    float currentTimeFalling;
    public bool moveBackWards;
    public float portalspeed;
    [Space(3)]

    [Header("Player Jump")]             //Jump variables
    public float jumpSpeed = 5f;
    [Space(3)]

    [Header("Player Checks")]           //Checks for mecanics
    public bool grounded;
    public bool crouched;
    public bool checkRoof;
    public bool isNotFalling;
    float groundCheckRadius = 0.2f; //groundCheck
    float roofCheckRadius = 0.2f;   //roofCheck
    [Space(3)]

    [Header("Mask for checks")]
    public LayerMask whatIsGround; //ground
    public LayerMask hasStrutureOnTop; //roof   

    [HideInInspector]
    public bool facingRight = true;
    public bool isMoving = true;
    bool WaitWalkBackwardsEnd;
    public bool portalSpeedPositive;
    
    //tirar efeito de andar ao contrario ao entrar no portal do lucas
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }


    protected void Update()
    {      
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (isMoving)
        {
            Move();
            Jump();
            Crouch();

            if (portalSpeedPositive&&portalspeed > 0)
            {
                portalspeed -= 1;
            }
            else if(portalSpeedPositive&&portalspeed <= 0) {
                portalspeed = 0;
            }
            if (!portalSpeedPositive && portalspeed < 0)
            {
                portalspeed += 1;
            }
            else if(!portalSpeedPositive&&portalspeed >= 0) {
                portalspeed = 0;
            }
            checkRoof = Physics2D.OverlapCircle(roofCheck.position, roofCheckRadius, hasStrutureOnTop);

            if (hasStrutureOnTop == 13)
            {
                checkRoof = true;
            }
            if (!grounded && rb.velocity.y < 0 && !isNotFalling)
            {
                currentTimeFalling += Time.deltaTime;
            }
            else
            {
                if (currentTimeFalling >= 0.5f)
                {
                    ph.Damage(5, false);
                }
                currentTimeFalling = 0;
            }

        }
        else if (grounded)
        {
            rb.velocity = Vector2.zero;
        }
        JumpAnimControll();


    }

    public void Flipp()
    {
        facingRight = !facingRight;

        sr.gameObject.transform.Rotate(0f, 180f, 0f); //Melhor para o uso de ataques
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded && !crouched)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }
    }

    void JumpAnimControll()
    {
        if (grounded)
        {
            anim.SetBool("Isjumping", false);
        }

        if (!grounded)
        {
            anim.SetBool("Isjumping", true);
        }

    }

    void Crouch()
    {

        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) || (checkRoof == true&& Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("Iscrouchwalk", true);
            speed = crouchSpeed;
            crouched = true;

        }

        if ((Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A)) || (checkRoof == true && Input.GetKey(KeyCode.D))))
        {
            anim.SetBool("Iscrouchwalk", true);
            speed = crouchSpeed;
            crouched = true;
        }

        if (Input.GetButtonDown("Down") && (grounded || checkRoof == true))
        {
            anim.SetBool("pressDown", true);
            ChangeCollidersCrouch();
            crouched = true;
        }

        if (!Input.GetButton("Down") && grounded && checkRoof == false)
        {
            anim.SetBool("pressDown", false);
            anim.SetBool("Iscrouchwalk", false);
            ChangeCollidersIdle();
            speed = speedFix;
            crouched = false;
        }
    }

    public virtual void Move()
    {     
        move = new Vector2((hMove * speed), rb.velocity.y);
        if (portalspeed != 0)
        {
            rb.velocity = new Vector2(portalspeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = move;
        }
        //rb.AddForce(move,ForceMode2D.Force);
        anim.SetFloat("speed", Mathf.Abs(hMove));

        if (hMove > 0 && facingRight == false)
        {
            Flipp();
        }
        else if (hMove < 0 && facingRight == true)
        {
            Flipp();
        }
        if (!moveBackWards)
        {
            if ((WaitWalkBackwardsEnd&&(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)))||!WaitWalkBackwardsEnd)
            {
                hMove = Input.GetAxis("Horizontal");
                WaitWalkBackwardsEnd = false;

            }
           /* else
            {
                hMove = -Input.GetAxis("Horizontal");
            }*/



        }
        /* else if (moveBackWards)
         {        
                 hMove = -Input.GetAxis("Horizontal");
             if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
             {
                 WaitWalkBackwardsEnd = true;
                 moveBackWards = false;
             }
             if (hMove ==0)
             {
                 if (!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.D))
                 {
                     moveBackWards = false;
                     hMove = 0f;

                 }
             }
         }*/
    }

    void ChangeCollidersCrouch()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = true;
        PlayerPlataformHead.transform.localPosition = new Vector3(0,-0.5f,0);
    }

    void ChangeCollidersIdle()
    {
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;
        PlayerPlataformHead.transform.localPosition = new Vector3(0, 0, 0);


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    void OnDrawGizmosSelectedd()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(roofCheck.position, roofCheckRadius);
    }

}

