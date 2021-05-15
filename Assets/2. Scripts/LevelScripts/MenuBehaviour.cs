using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour {
    public GameObject buttons;
    public GameObject options;
    // Use this for initialization
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Options() {
        buttons.SetActive(!buttons.activeInHierarchy);
        options.SetActive(!options.activeInHierarchy);
    }
    public void Quit() {
        Application.Quit();
    }
}
