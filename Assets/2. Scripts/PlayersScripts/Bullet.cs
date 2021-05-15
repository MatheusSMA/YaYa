using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject,3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.layer==2)
        {
            return;
        }
       EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

       GameObject impactEffectt = Instantiate(impactEffect, transform.position, transform.rotation);        
        Destroy(impactEffectt,0.3f);
        Destroy(gameObject);
    }
}