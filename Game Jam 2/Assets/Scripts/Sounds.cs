using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] AudioSource startButton;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource pauseButton;
    [SerializeField] AudioSource unpauseButton;

    public static Sounds instance = null;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
	}


    //Plays All Sounds

    public void PlayStartButton()
    {
        startButton.Play();
    }

    public void PlayPauseButton()
    {
        pauseButton.Play();
    }

    public void PlayUnPause()
    {
        unpauseButton.Play();
    }

    public void PlayDeathSound()
    {
        deathSound.Play();
    }

    public void PlayJump()
    {
        jumpSound.Play();
    }

    public void PlayBackGroundMusic()
    {
        backGroundMusic.Play();
    }
}
