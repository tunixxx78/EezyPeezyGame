using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PLRData
{
    public int score, aliensFound;

    public PLRData (ScoringSystem player)
    {
        score = player.theGameScore;
        aliensFound = player.numberOfAliensFound;
    }
}
