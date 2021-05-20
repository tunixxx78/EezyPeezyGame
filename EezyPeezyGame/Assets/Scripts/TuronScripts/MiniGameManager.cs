using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject minigameOne;

    private void Start()
    {
        if (ScoringSystem.theScore >= 10)
        {
            MoveToArcade();
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
