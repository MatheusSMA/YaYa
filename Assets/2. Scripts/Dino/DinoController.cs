using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : PlayerController
{
    bool attacking;
    float timerAttack;
    float TotaltimeAttack=0.8f;
    public float damage;
    public GameObject Damage;
    float normalspeed;
    public GameObject FireDamage;
    public Transform SpriteRotation;

    // Use this for initialization
    void Start()
    {
        base.Start();
        normalspeed = speed;
        speedFix = 6.5f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!isMoving)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            attacking = true;
            Damage.SetActive(true);

        }
        if (Input.GetKey(KeyCode.G))
        {
            attacking = true;
            FireDamage.SetActive(true);
        }
        if (attacking)
        {
            speed = 0;
            if (Damage.activeInHierarchy)
            {
                if (facingRight)
                {
                    rb.AddForce(transform.right * 13, ForceMode2D.Impulse);

                }
                else
                {
                    rb.AddForce(-transform.right * 13, ForceMode2D.Impulse);
                }
            }
            else if(FireDamage.activeInHierarchy) {
                FireDamage.transform.rotation = SpriteRotation.rotation;
            }
            timerAttack += Time.deltaTime;
            if (timerAttack>TotaltimeAttack)
            {
                attacking = false;
                timerAttack = 0;
                Damage.SetActive(false);
                FireDamage.SetActive(false);
                speed = normalspeed;
            }


        }
    }
}


