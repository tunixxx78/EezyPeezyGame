using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;

    public void StartThisGame()
    {
        startScreen.SetActive(false);
    }
}
