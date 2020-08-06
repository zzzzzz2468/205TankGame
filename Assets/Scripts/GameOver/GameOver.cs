using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI congrats;
    public TextMeshProUGUI score;
    public ScoreData data;

    void Start()
    {
        congrats.text = "Congrats " + data.playerName;
        score.text = "Score " + data.playerScore.ToString("N0");
    }
}