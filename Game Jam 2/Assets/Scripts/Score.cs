using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public Text highScore;

    private float currentScoreCount = 0.0f;
    private float topScore;
    private Vector3 distance;

    [SerializeField] GameObject player;
    private bool isPlayerAlive = true;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Mathf.Abs(currentScoreCount);
        currentScoreCount = distance.z + player.transform.position.z;
        score.text = "Score: " + currentScoreCount + "m";
	}

}
