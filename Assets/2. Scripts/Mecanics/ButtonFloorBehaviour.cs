using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFloorBehaviour : MonoBehaviour
{
    public GameObject door;
    public Animator animButton;
    int timer;
    float count;
    bool isCount = false;
    // Use this for initialization
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            door.SetActive(false);
            isCount = false;
            count = 0;
            animButton.SetBool("Activaded", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCount = true;
            animButton.SetBool("Activaded", false);

        }
    }

    private void Update()
    {
        if (isCount == true)
        {
            count += Time.deltaTime;
            Debug.Log(count);
        }

        if(count >= 0.1f)
        {
            isCount = false;
            door.SetActive(true);
        }
    }
}
