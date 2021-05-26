using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject minigameOne, minigameTwo, minigamethree;
    public bool newScene;

    private void Start()
    {
        if (ScoringSystem.theScore >= 10 && ScoringSystem.theScore <= 100)
        {
            minigameOne.SetActive(false);
            minigameTwo.SetActive(true);
        }
        else if (ScoringSystem.theScore >= 100 && ScoringSystem.theScore <= 500)
        {
            minigameOne.SetActive(false);
            minigameTwo.SetActive(false);
            minigamethree.SetActive(true);
        }
        else if (ScoringSystem.theScore >= 500)
        {
            minigameOne.SetActive(false);
            minigameTwo.SetActive(false);
            minigamethree.SetActive(false);
        }
    }

    public void LoadScene(string SceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if ( currentScene.name != SceneName)
        {
            newScene = true;
            SceneManager.LoadScene(SceneName);
        }
    }

    public void MoveToArcade()
    {
        minigameOne.SetActive(false);
        
    }
}
