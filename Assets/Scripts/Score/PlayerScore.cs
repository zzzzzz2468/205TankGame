using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //different variables for deciding score
    public float scorePerSec = 0.01f;
    public float scorePerKill = 20.0f;
    public ScoreData playerScoreData;

    //sets team name
    private void Start()
    {
        playerScoreData.playerName = GameManager.Instance.txtTeamName;
    }

    //updates the score
    private void Update()
    {
        playerScoreData.playerScore += scorePerSec;
    }

    //adds score to current game
    void OnDestroy()
    {
        GameManager.Instance.currentGame.Add(playerScoreData);
    }
}