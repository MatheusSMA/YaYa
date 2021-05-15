using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public YagoController yagoC;
    public GameObject pauseMenuUI;
    public GameObject HealthBarUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        HealthBarUI.SetActive(false);
        Time.timeScale = 0f;
        yagoC.weapon.CrosshairOFF();
        yagoC.paused = true;
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        HealthBarUI.SetActive(true);
        Time.timeScale = 1f;
        yagoC.weapon.Crosshair();
        yagoC.paused = false;

    }

    public void LoadScene()
    {
        
    }

    public void QuitGame()
    {

    }
}
