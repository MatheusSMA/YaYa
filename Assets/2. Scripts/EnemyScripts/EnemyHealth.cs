using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 100;
    float currenthealth;
    public Slider healthbar;
    public GameObject deathParticle;
    public EnemyPatrol ep;
    float timer;
    public float timetonormal;
    bool tookDamage;
    public bool canTakeStun;
    private void Start()
    {
        currenthealth = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = currenthealth;
    }
    private void Update()
    {      
        if (ep.stuned)
        {
            timer += Time.deltaTime;
            if (timer>=timetonormal||tookDamage)
            {
                timer = 0;
                ep.stuned = false;
            }
        }
    }
    public void TakeDamage(float amount,bool KnockBack = false)
    {
        tookDamage = true;
        currenthealth -= amount;
        healthbar.value = currenthealth;
        StartCoroutine(EnemyInvulnerable());
        if (currenthealth <=0)
        {
            //Kill me
            if (deathParticle)
            {
                Instantiate(deathParticle, transform.position, Quaternion.identity);
            }
            //gameObject.SetActive(false);
            //healthbar.transform.parent.gameObject.SetActive(false);
          
                Destroy(gameObject);
            
        }
    }

    public IEnumerator EnemyInvulnerable() 
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        yield return new WaitForSeconds (0.2f);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        tookDamage = false;
    }
    public void Stun() {
        if (canTakeStun)
        {
            ep.stuned = true;
            print("a");
            timer = 0;
        }
    }
}
