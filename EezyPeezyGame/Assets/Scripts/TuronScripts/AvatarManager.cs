using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarManager : MonoBehaviour
{
    [SerializeField] GameObject[] robots;
    int RobotIndex;

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
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("RobotIndex", RobotIndex);
    }
}
