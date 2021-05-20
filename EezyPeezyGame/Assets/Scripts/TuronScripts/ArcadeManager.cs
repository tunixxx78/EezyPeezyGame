using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeManager : MonoBehaviour
{
    [SerializeField] GameObject gameOne;

    private void Start()
    {
        if (ScoringSystem.theScore >= 10)
        {
            gameOne.SetActive(true);
        }

    }

    public void BackToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
