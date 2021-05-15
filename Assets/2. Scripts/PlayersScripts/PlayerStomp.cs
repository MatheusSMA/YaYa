using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStomp : MonoBehaviour {
    public float damage;
    public float jumpForce;
    public float distance;
    public LayerMask whatIsEnemy;
    PlayerController pc;
    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!pc.grounded && pc.rb.velocity.y < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, whatIsEnemy);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<EnemyHealth>())
                {
                    hit.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                    pc.rb.velocity = Vector2.zero;
                    pc.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }

            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.down * distance);
    }
}