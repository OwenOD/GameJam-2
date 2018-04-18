using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject PlayScreen;
    public GameObject PauseScreen;
    public GameObject pauseButton;
 
    public bool isPaused;
    // Use this for initialization
    void Start ()
    {
        isPaused = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        PlayScreen.SetActive(false);

 

        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);


        isPaused = false;
    }
}
