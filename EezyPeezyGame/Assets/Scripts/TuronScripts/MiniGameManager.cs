using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject minigameOne, minigameTwo;

    private void Start()
    {
        if (ScoringSystem.theScore >= 10)
        {
            MoveToArcade();
            minigameTwo.SetActive(true);

        }
    }


    public void StartThisGame()
    {
        SceneManager.LoadScene("DashboardAssembly");
        
    }

    public void MoveToArcade()
    {
        minigameOne.SetActive(false);
        
    }

    public void GoToArcade()
    {
        SceneManager.LoadScene("MiniGameArcade");
    }
}
