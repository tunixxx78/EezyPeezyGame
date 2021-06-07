using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMemory : MonoBehaviour
{
    private void Start()
    {
        ScoringSystem.theScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        ScoringSystem.numberOfAliens = 0;
        PlayerPrefs.SetInt("NumberOfAliens", 0);
    }
}
