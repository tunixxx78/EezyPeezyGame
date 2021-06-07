using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarManager : MonoBehaviour
{
    [SerializeField] GameObject[] robots;
    int RobotIndex;

    private void Start()
    {
        ScoringSystem.theScore = 0;
        PlayerPrefs.SetInt("HighScore", 0);
        ScoringSystem.numberOfAliens = 0;
        PlayerPrefs.SetInt("NumberOfAliens", 0);
    }

    public void ChangeRobot(int index)
    {
        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].SetActive(false);
        }
        this.RobotIndex = index;
        robots[index].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HomePlanet");
        PlayerPrefs.SetInt("RobotIndex", RobotIndex);
    }
}
