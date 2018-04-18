using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float highscore;

    public static GameManager instance = null;

	void Awake ()
    {
        if (instance)
            Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

	}
	
	void Update ()
    {
		
	}
}
