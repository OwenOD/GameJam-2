using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject PlayScreen;
    public GameObject PauseScreen;
    public GameObject pauseButton;
    public GameObject GameOverScreen;

    public bool isPaused;
    // Use this for initialization
    void Start ()
    {
        isPaused = false;
        Sounds.instance.PlayMenuMusic();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        PlayScreen.SetActive(false);
        Sounds.instance.PlayMenuMusic();

        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);
        Sounds.instance.PlayBackGroundMusic();

        isPaused = false;
    }
    public void GameOver()
    {
        PlayScreen.SetActive(false);
        GameOverScreen.SetActive(true);
        Sounds.instance.PlayMenuMusic();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
