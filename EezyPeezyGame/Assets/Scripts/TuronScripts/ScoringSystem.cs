using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static int theScore;
    public static int numberOfAliens;
    public static int theDots;

    public int theGameScore;
    public int numberOfAliensFound;

    [SerializeField] Text aliensCount, pointsCount;
    private void Start()
    {
        theGameScore = theScore;
        numberOfAliensFound = numberOfAliens;
        NumberOfAliens();
        PlayerScore();
    }

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
        if (theDots > PlayerPrefs.GetInt("DotsCollected", 0))
        {
            PlayerPrefs.SetInt("DotsCollected", theDots);
        }
    }

    private void NumberOfAliens()
    {
        int numberOfAliens = PlayerPrefs.GetInt("NumberOfAliens");
        aliensCount.text = numberOfAliensFound.ToString();
      


    }

    private void PlayerScore()
    {
        int theScore = PlayerPrefs.GetInt("HighScore");
        pointsCount.text = theGameScore.ToString();
        
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PLRData data = SaveSystem.LoadPlayer();

        theGameScore = data.score;
        numberOfAliensFound = data.aliensFound;

        
        

        NumberOfAliens();
        PlayerScore();
        
    }
}
