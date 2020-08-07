using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float scorePerSec = 0.01f;
    public float scorePerKill = 20.0f;
    public ScoreData playerScoreData;

    private void Start()
    {
        playerScoreData.playerName = GameManager.Instance.txtTeamName;
    }

    private void Update()
    {
        playerScoreData.playerScore += scorePerSec;
    }

    void OnDestroy()
    {
        GameManager.Instance.currentGame.Add(playerScoreData);
    }
}