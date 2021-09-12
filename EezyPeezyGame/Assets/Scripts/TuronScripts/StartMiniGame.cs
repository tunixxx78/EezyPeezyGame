using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abandoned part of game logic

public class StartMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    public void StartThisGame()
    {
        if (startScreen.activeSelf == true)
        {
            startScreen.SetActive(false);
        }
    }
}
