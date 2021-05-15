using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform CurrentCheckpoint;
    public GameObject player;
    public PlayerController pc;

    public TextMeshProUGUI healthTXT;
    public Texture2D cursorTexture;
    public Slider healthSlider;
    public int currentGems = 0;
    public TextMeshProUGUI gemsTXT;

    public Animator transitionPanelAdmin;
    public float timePortalPlayer;

    public static LevelManager instance;                    //passar tudo para outros scripts com LevelManager.instance. o que vc precisa 
    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        if (gemsTXT!=null)
        {
            gemsTXT.text = "x " + currentGems.ToString();
        }
        pc = player.GetComponent<PlayerController>();

    }
    
    public void UpdateHealthBar(float amount)
    {
        if (healthSlider!=null)
        {
            healthSlider.value = amount;

        }
        if (healthTXT!=null)
        {
            healthTXT.text = healthSlider.value.ToString() + "%";

        }
    }

    public void AddGem()
    {
        currentGems++;
        gemsTXT.text = "x " + currentGems.ToString();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerSequence());
    }

    public IEnumerator RespawnPlayerSequence()
    {
        pc.rb.velocity = Vector3.zero;
        pc.rb.isKinematic = true;
        pc.isMoving = false;
        pc.anim.SetBool("isHurt", true);
        transitionPanelAdmin.Play("LeftIn");
        yield return new WaitForSeconds(2);
        transitionPanelAdmin.Play("LeftOut");
        pc.anim.SetBool("isHurt", false);
        pc.isMoving = true;
        pc.rb.isKinematic = false;


        player.transform.position = CurrentCheckpoint.position;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
