using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //public Text scoreText;

    private float currentScoreCount;
    private float highScore;
    private float distance;

    [SerializeField] GameObject player;
    [SerializeField] bool isPlayerAlive = true;

    // Use this for initialization
    void Start ()
    {
        //distance = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

        while (isPlayerAlive == true)
        {
            currentScoreCount++;
        }
	}
}
