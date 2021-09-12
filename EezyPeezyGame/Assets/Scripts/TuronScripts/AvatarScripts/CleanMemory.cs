using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is for cleaning memory at the start of game.

public class CleanMemory : MonoBehaviour
{
    private void Start()
    {
        ScoringSystem.theScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        ScoringSystem.numberOfAliens = 0;
        PlayerPrefs.SetInt("NumberOfAliens", 0);
        ScoringSystem.theDots = 0;
        PlayerPrefs.SetInt("DotsCollected", 0);
    }
}
