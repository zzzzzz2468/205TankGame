using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float scorePerSec = 0.01f;
    public float scorePerKill = 20.0f;
    public ScoreData playerScoreData;

    private void Update()
    {
        playerScoreData.playerScore += scorePerSec;
    }

    void AddScoreToHighScores()
    {
        GameManager.Instance.highScores.Add(playerScoreData);
    }
}