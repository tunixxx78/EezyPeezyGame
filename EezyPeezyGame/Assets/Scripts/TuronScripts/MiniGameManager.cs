using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject minigameOne;

    public void StartThisGame()
    {
        SceneManager.LoadScene("DashboardAssembly");
        minigameOne.SetActive(false);
    }

    public void MoveToArcade()
    {
        minigameOne.SetActive(false);
    }
}
