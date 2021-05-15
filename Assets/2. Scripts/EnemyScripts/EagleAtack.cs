using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAtack : MonoBehaviour
{
    public float movespeed = 2f;
    private bool attack = false;
    private bool facingRight = true;
    private bool contadorPerseguindoAlgo = false;
    private float cronometroDaPerseguicao;
    private bool vendoOPlayer = false;
    public GameObject parent;

    public PlayerController player;

    public Transform[] wayPoints;
    int wayPointIndex = 0;

    void Start()
    {
        parent.transform.position = wayPoints[wayPointIndex].transform.position;
    }

    void Update()
    {
        if (attack == false)
        {
            Move();
        }
        if (contadorPerseguindoAlgo == true)
        {
            cronometroDaPerseguicao += Time.deltaTime;
            attack = true;
            Attack();
        }
        if (cronometroDaPerseguicao >= 5 && vendoOPlayer == false)
        {
            contadorPerseguindoAlgo = false;
            cronometroDaPerseguicao = 0;
            attack = false;
        }
        if (parent.transform.position == wayPoints[1].transform.position || parent.transform.position == wayPoints[0].transform.position)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void Move()
    {
        parent.transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, movespeed * Time.deltaTime);

        if (parent.transform.position == wayPoints[wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
        }

        if (wayPointIndex == wayPoints.Length)
        {
            wayPointIndex = 0;
        }
    }

    void Attack()
    {
        parent.transform.position = Vector3.MoveTowards(parent.transform.position, player.transform.position, movespeed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            vendoOPlayer = true;
            contadorPerseguindoAlgo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            vendoOPlayer = false;
        }
    }
}
