using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ScoreData : IComparable<ScoreData>
{
    public float playerScore;
    public string playerName;

    public int CompareTo(ScoreData other)
    {
        if (other == null)
            return 1;
        if (playerScore > other.playerScore)
            return 1;
        if (playerScore < other.playerScore)
            return -1;
        return 0;
    }
}