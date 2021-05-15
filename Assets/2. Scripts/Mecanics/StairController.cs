using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{

    public float speed = 6;
    public bool isLadder = false;                //Seta a animação dentro do animator
    public PlayerController playerC;
    int animSpeed;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerC = other.gameObject.GetComponent<PlayerController>();
        }

        if (other.tag == "Player" && Input.GetKey(KeyCode.W) && !playerC.crouched)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            isLadder = true;
            playerC.anim.SetBool("isLadder", true);

        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.S) && !playerC.crouched)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            isLadder = true;
            playerC.anim.SetBool("isLadder", true);
            playerC.isNotFalling = true;
        }
        else if(other.tag=="Player")
        {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
            //PlayAnimation stopped in stair
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerC.isNotFalling = false;
            isLadder = false;
            other.GetComponent<Rigidbody2D>().gravityScale = 5.5f;
            playerC.anim.SetBool("isLadder", false);
        }
    }
}

   
