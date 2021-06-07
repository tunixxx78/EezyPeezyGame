using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    [SerializeField] GameObject loginScreen, registerScreen, startGameScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }
     
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoginScreen()
    {
        loginScreen.SetActive(true);
        registerScreen.SetActive(false);
    }
    public void StartGameScreen()
    {
        startGameScreen.SetActive(true);
        loginScreen.SetActive(false);
    }
}
