using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeManager : MonoBehaviour
{
    [SerializeField] GameObject gameOne, game2, game3;

    private void Start()
    {
        if (ScoringSystem.theScore >= 10 && ScoringSystem.theScore <= 100)
        {
            gameOne.SetActive(true);
        }
        if (ScoringSystem.theScore >= 100 && ScoringSystem.theScore <= 500)
        { 
            gameOne.SetActive(true);
            game2.SetActive(true);
        }
        if (ScoringSystem.theScore >= 500)
        {
            gameOne.SetActive(true);
            game2.SetActive(true);
            game3.SetActive(true);
        }

    }

    public void BackToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
