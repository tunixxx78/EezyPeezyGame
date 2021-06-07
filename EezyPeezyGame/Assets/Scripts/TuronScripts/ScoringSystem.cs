using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    public static int numberOfAliens;


    private void Update()
    {
        if (theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
        }
        if (numberOfAliens > PlayerPrefs.GetInt("NumberOfAliens", 0))
        {
            PlayerPrefs.SetInt("NumberOfAliens", numberOfAliens);
        }
    }
}
