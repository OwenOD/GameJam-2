using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject PlayScreen;
    public GameObject PauseScreen;
    public GameObject pauseButton;
    [SerializeField] AudioClip pauseClip;
    [SerializeField] AudioClip unpauseClip;

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

        Sounds.instance.PlayPauseButton(pauseClip);

        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);

        Sounds.instance.PlayUnPause(pauseClip);

        isPaused = false;
    }
}
