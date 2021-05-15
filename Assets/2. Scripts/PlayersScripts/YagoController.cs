using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YagoController : PlayerController
{
    [Space(5)]
    [Header("Weapon components")]
    public GameObject Arm;
    public WeaponNew weapon;
    bool setGunBackToOn;
    bool setArrowBack = true;
    public bool paused;


    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        if (isMoving && !paused)
        {
            if (crouched)
            {
                if (Arm.activeInHierarchy)
                {
                    setGunBackToOn = true;
                }
                Arm.SetActive(false);
                weapon.CrosshairOFF();
            }
            else if (setGunBackToOn)
            {
                Arm.SetActive(true);
                setGunBackToOn = false;
                weapon.Crosshair();

            }
            else if (Input.GetMouseButtonDown(1))
            {
                Arm.SetActive(!Arm.activeInHierarchy);
                setArrowBack = !setArrowBack;
                if (setArrowBack == true)
                {
                    weapon.Crosshair();
                }
                else
                {
                    weapon.CrosshairOFF();
                }

            }
        }
        
    }
    private void FixedUpdate()
    {   //GLIDE, BOTAR EM OUTRO PERSONAGEM OU NO YAGO?
       /* if (!grounded && rb.velocity.y < 0)
        {
            print(0.4f / -rb.velocity.y);
            rb.gravityScale = Mathf.Clamp(0.8f / -rb.velocity.y, -1, 5.5f);
        }
        else
        {
            rb.gravityScale = 5.5f;

        }*/
    }

    public override void Move()
    {
        hMove = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(hMove));
        if (!weapon.gameObject.activeInHierarchy)
        {

            if (hMove > 0 && facingRight == false)
            {
                Flipp();
            }
            else if (hMove < 0 && facingRight == true)
            {
                Flipp();
            }
        }
    }
}
