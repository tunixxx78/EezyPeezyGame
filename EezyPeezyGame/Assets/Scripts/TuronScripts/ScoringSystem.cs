using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// partly abandoned saveSystem and partly keeping score in game.

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem scoringInstance;

    public static int theScore;
    public static int numberOfAliens;
    public static int theDots;

    public int theGameScore;
    public int numberOfAliensFound;
    public string currentScene;

    public bool tutorialDialogDone;

    [SerializeField] Text aliensCount, pointsCount;

    private void Awake()
    {
        theGameScore = theScore;
        numberOfAliensFound = numberOfAliens;
    }

    private void Start()
    {
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

        currentScene = SceneManager.GetActiveScene().name;

        if (DataHolder.dataHolder.tutorialDone)
        {
            tutorialDialogDone = true;
            GameProgress();
        }

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

    public void GameProgress()
    {
        tutorialDialogDone = true;
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
        currentScene = data.activeScene;
        tutorialDialogDone = data.tutorial;

        pointsCount.text = theGameScore.ToString();
        aliensCount.text = numberOfAliensFound.ToString();

        theScore = theGameScore;
        numberOfAliens = numberOfAliensFound;

        Debug.Log("Loaded from " + theScore);
        Debug.Log("Loaded from " + numberOfAliens);

        SceneManager.LoadScene(currentScene);
        
    }
}
