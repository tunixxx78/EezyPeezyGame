using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    [SerializeField] GameObject loginScreen, registerScreen, startGameScreen, creditsPanel, avatar;
    [SerializeField] InputField userInput, passwordInput;

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
        //PrefabUtility.SaveAsPrefabAsset(avatar, "assets/Prefabs/TestPrefabs/avatar.prefab");
        SceneManager.LoadScene("HomePlanet");
    }

    public void ArcadeMode()
    {
        DataHolder.dataHolder.tutorialDone = true;
        DataHolder.dataHolder.lobbyDone = true;
        DataHolder.dataHolder.cockpitDone = true;
        DataHolder.dataHolder.dashboardDone = true;
        DataHolder.dataHolder.phoneCallDone = true;
        DataHolder.dataHolder.headquartersDone = true;
        DataHolder.dataHolder.labyrinthDone = true;
        DataHolder.dataHolder.engineFloorDone = true;
        DataHolder.dataHolder.FuelPipesDone = true;
        DataHolder.dataHolder.engineStartDone = true;
        DataHolder.dataHolder.spaceTransitDone = true;
        DataHolder.dataHolder.gridNavigationDone = true;
        DataHolder.dataHolder.medicineMeasureDone = true;
        DataHolder.dataHolder.newtonTreatedDone = true;

        SceneManager.LoadScene("RocketArcade");
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

    public void Credits()
    {
        if(creditsPanel.activeSelf == true)
        {
            creditsPanel.SetActive(false);
        }
        else
        {
            creditsPanel.SetActive(true);
        }
    }


}
