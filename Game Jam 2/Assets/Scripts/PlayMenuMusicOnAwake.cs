using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuMusicOnAwake : MonoBehaviour
{

	void Start ()
    {
        Sounds.instance.PlayMenuMusic();
	}
	
}
