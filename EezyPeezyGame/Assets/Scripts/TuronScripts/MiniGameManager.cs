using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] GameObject minigameOne;
    [SerializeField] GameObject[] buttons;
    private int buttonIndex;

    public void HideButtons(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        this.buttonIndex = index;
        buttons[index].SetActive(false);
    }

    public void StartThisGame()
    {
        SceneManager.LoadScene("DashboardAssembly");
        //minigameOne.SetActive(false);
        PlayerPrefs.SetInt("miniGameManager", buttonIndex);
    }

    public void MoveToArcade()
    {
        minigameOne.SetActive(false);
    }
}
