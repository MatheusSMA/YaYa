using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCharacters : MonoBehaviour
{

    public PlayerController player1, player2,player3;
    public GameObject gun;
    public CinemachineVirtualCamera cm;
    int whichPlayerIsOn = 2;

    void Start()
    {
        player1.gameObject.SetActive(true);
    }
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        whichPlayerIsOn++;
        if (whichPlayerIsOn>3)
        {
            whichPlayerIsOn = 1;
        }
        switch (whichPlayerIsOn)
        {
            case 1: //Lucas
                cm.Follow = player2.transform;
                player1.isMoving = false;
                player3.isMoving = false;
                //player1.enabled = false;
                gun.GetComponent<WeaponNew>().enabled = false;
                player2.isMoving = true;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
               // player1.rb.velocity = Vector2.zero;
                player1.anim.SetBool("SwitchedPlayer", true);
                player2.anim.SetBool("SwitchedPlayer",false);
                player3.anim.SetBool("SwitchedPlayer", false);
                LevelManager.instance.UpdateHealthBar(player2.GetComponent<PlayerHealth>().currentHealth);

                break;

            case 2: //Yago
                cm.Follow = player1.transform;
                player1.gameObject.SetActive(true);
                player1.isMoving = true;
                player3.isMoving = false;
                gun.GetComponent<WeaponNew>().enabled = true;
                player2.isMoving = false;
                if (gun.activeInHierarchy)
                {
                    Cursor.SetCursor(LevelManager.instance.cursorTexture, Vector2.zero, CursorMode.Auto);
                }
                //player2.rb.velocity = Vector2.zero;
                player1.anim.SetBool("SwitchedPlayer", false);
                player2.anim.SetBool("SwitchedPlayer",true);
                player3.anim.SetBool("SwitchedPlayer", false);
                LevelManager.instance.UpdateHealthBar(player1.GetComponent<PlayerHealth>().currentHealth);


                break;
            case 3:
                cm.Follow = player3.transform;
                gun.GetComponent<WeaponNew>().enabled = false;
                player3.gameObject.SetActive(true);
                player3.isMoving = true;
                player2.isMoving = false;
                player1.isMoving = false;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                player2.anim.SetBool("SwitchedPlayer", false);
                player3.anim.SetBool("SwitchedPlayer", true);
                player1.anim.SetBool("SwitchedPlayer", false);
                LevelManager.instance.UpdateHealthBar(player3.GetComponent<PlayerHealth>().currentHealth);
                break;

        }
    }

}
