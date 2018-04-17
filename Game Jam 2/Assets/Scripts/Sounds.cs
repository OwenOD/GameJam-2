using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource backGroundMusic;
    public static Sounds instance = null;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
	}



    public void PlayJump(AudioClip clip)
    {
        jumpSound.Play();
    }

    public void BackGroundMusic()
    {
        backGroundMusic.Play();
    }
}
