using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    PlayerController pc;
    

    public float maxHealth = 100;
    public float currentHealth;

    public Vector2 knockbackForce;
    public float knockbacktime = 0.3f;
    public float InvulnerableTime = 1.5f;
    public Color invulnerableColor;
    public Color playerColor;
    public bool Dino;
    void Start()
    {
        pc = GetComponent<PlayerController>();
       
        currentHealth = maxHealth;
        if (LevelManager.instance.healthSlider!=null)
        {
            LevelManager.instance.healthSlider.maxValue = maxHealth;
            LevelManager.instance.UpdateHealthBar(currentHealth);

        }
      
    }
	
	
    public void Medkit (float amount)
    {
        currentHealth += amount;
        LevelManager.instance.UpdateHealthBar(currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Damage(float amount, bool knockbackLeft,bool DamageDino=false)
    {
        if (Dino&&!DamageDino)
        {
            return;
        }
        currentHealth -= amount;
        if (DamageDino&&Dino)
        {
            currentHealth -=amount*3;
        }
        LevelManager.instance.UpdateHealthBar(currentHealth);
        StartCoroutine (DamageSequence(knockbackLeft));        
        if (currentHealth <= 0)
        {
            //GameOver
            currentHealth = 0;
            LevelManager.instance.GameOver();
        }        
    }

    public IEnumerator DamageSequence(bool knockbackLeft)
    {
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        pc.sr.color = invulnerableColor;
        pc.isMoving = false;

        if (knockbackLeft)
            pc.rb.AddForce(new Vector2(-knockbackForce.x, knockbackForce.y), ForceMode2D.Impulse);
        else
            pc.rb.AddForce(knockbackForce, ForceMode2D.Impulse);

        pc.anim.SetBool ("isHurt", true);
        yield return new WaitForSeconds(knockbacktime);
        pc.anim.SetBool("isHurt", false);
        pc.isMoving = true;
        yield return new WaitForSeconds(InvulnerableTime);
        pc.sr.color = playerColor;
        gameObject.layer = LayerMask.NameToLayer("Player"); 

    }   

}
