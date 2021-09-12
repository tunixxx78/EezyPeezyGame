using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of abandonet saveSystem.

[System.Serializable]
public class PLRData
{
    public int score, aliensFound;
    public string activeScene;
    public bool tutorial;

    public PLRData (ScoringSystem player)
    { 
        score = player.theGameScore;
        aliensFound = player.numberOfAliensFound;
        activeScene = player.currentScene;
        tutorial = player.tutorialDialogDone;
    }
}
