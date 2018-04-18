using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource backGroundMusic;
    [SerializeField] AudioSource menuMusic;
    [SerializeField] AudioSource deathSound;

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

    public void PlayMenuMusic()
    {
        menuMusic.Play();
    }
}
