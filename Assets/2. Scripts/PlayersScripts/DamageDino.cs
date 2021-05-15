using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDino : MonoBehaviour {
    public float damage = 40;

    void OnTriggerEnter2D(Collider2D cd) {
        if (cd.tag == "Enemy")
        {
            cd.GetComponent<EnemyHealth>().TakeDamage(damage);

        }
    }
}
