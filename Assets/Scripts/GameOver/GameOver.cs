using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI score;
    public ScoreData data;

    private float totalScore;

    void Start()
    {
        congrats.text = "Congrats " + GameManager.Instance.currentGame[0].playerName;

        foreach(ScoreData score in GameManager.Instance.currentGame)
        {
            totalScore += score.playerScore;
        }

        score.text = "Score " + totalScore.ToString("N0");
    }
}