using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    //text and score data
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI score;
    public ScoreData data;

    //total score between both players
    private float totalScore;

    //changes the text in the game over screen
    void Start()
    {
        congrats.text = "Congrats " + GameManager.Instance.currentGame[0].playerName;

        foreach(ScoreData score in GameManager.Instance.currentGame)
        {
            totalScore += score.playerScore;
        }

        score.text = "Score " + totalScore.ToString("N0");

        PlayerPrefs.SetFloat("PlayerScore", totalScore);
        PlayerPrefs.SetString("PlayerName", GameManager.Instance.currentGame[0].playerName);
    }
}