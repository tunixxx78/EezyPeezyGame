using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem scoringInstance;

    public static int theScore;
    public static int numberOfAliens;
    public static int theDots;

    public int theGameScore;
    public int numberOfAliensFound;

    [SerializeField] Text aliensCount, pointsCount;

    private void Awake()
    {
        theGameScore = theScore;
        numberOfAliensFound = numberOfAliens;

        /*if (scoringInstance != null && scoringInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        scoringInstance = this;
        DontDestroyOnLoad(this);*/
    }

    private void Start()
    {
        //theGameScore = theScore;
        //numberOfAliensFound = numberOfAliens;
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

        theGameScore = theScore;
        numberOfAliensFound = numberOfAliens;

        //NumberOfAliens();
        //PlayerScore();
    }

    private void NumberOfAliens()
    {
        int numberOfAliens = PlayerPrefs.GetInt("NumberOfAliens");
        aliensCount.text = numberOfAliensFound.ToString();
        numberOfAliensFound = numberOfAliens;


    }

    private void PlayerScore()
    {
        int theScore = PlayerPrefs.GetInt("HighScore");
        pointsCount.text = theGameScore.ToString();
        theGameScore = theScore;
        
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

        pointsCount.text = theGameScore.ToString();
        aliensCount.text = numberOfAliensFound.ToString();
        //NumberOfAliens();
        //PlayerScore();

        theScore = theGameScore;
        numberOfAliens = numberOfAliensFound;

        //theGameScore = theScore;
        //numberOfAliensFound = numberOfAliens;

        Debug.Log("Loaded from " + theScore);
        Debug.Log("Loaded from " + numberOfAliens);

        SceneManager.LoadScene("HomePlanet");
        
    }
}
