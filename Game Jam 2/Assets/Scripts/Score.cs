using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text score;
    public Text highScore;

    private float currentScoreCount;
    private float topScoreCount;

    GameObject player;

    Player playerScript;

    static Score instance = null;

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            player = GameObject.FindGameObjectWithTag("Player");
        }

        playerScript = player.GetComponent<Player>();
    }

    private void OnLevelWasLoaded(int level)
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        currentScoreCount = player.transform.position.z;
        currentScoreCount = Mathf.Abs(currentScoreCount);
        score.text = "Score: " + currentScoreCount.ToString("F2") + "m";

        if (playerScript.alive == false)
        {
            PlayerPrefs.SetFloat("HighScore", topScoreCount);                   //Saves the HighScore
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (currentScoreCount > topScoreCount)
        {
            topScoreCount = currentScoreCount;
        }

        highScore.text = "HighScore: " + topScoreCount.ToString("F2") + "m";
    }
}
