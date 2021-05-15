using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float damage = 20;
    public bool DamageDino;

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.tag == "Player")
        {
                if (other.transform.position.x > transform.position.x)
                {
                    other.GetComponent<PlayerHealth>().Damage(damage, false,DamageDino);
                }
                else
                {
                    other.GetComponent<PlayerHealth>().Damage(damage, true,DamageDino);
                } 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    other.gameObject.GetComponent<PlayerHealth>().Damage(damage, false,DamageDino);
                }
                else
                {
                    other.gameObject.GetComponent<PlayerHealth>().Damage(damage, true,DamageDino);
                }
            
        }
    }
}
