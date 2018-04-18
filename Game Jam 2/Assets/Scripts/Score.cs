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

    [SerializeField] GameObject player;

    Player playerScript;

    GameManager gm;

    [SerializeField] Menu menu;

    void Awake()
    {
        playerScript = player.GetComponent<Player>();

    }
    void Start()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        currentScoreCount = player.transform.position.z;
        currentScoreCount = Mathf.Abs(currentScoreCount);
        score.text = "Score: " + currentScoreCount.ToString("F2") + "m";

        if (playerScript.alive == false)
        {
            PlayerPrefs.SetFloat("HighScore", gm.highscore);                   //Saves the HighScore

            menu.GameOver();
        }

        if (currentScoreCount > gm.highscore)
        {
            gm.highscore = currentScoreCount;
        }

        highScore.text = "HighScore: " + gm.highscore.ToString("F2") + "m";
    }
}
