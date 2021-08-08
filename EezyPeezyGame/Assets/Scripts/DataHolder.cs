using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DataHolder : MonoBehaviour
{
    public static DataHolder dataHolder;
    public string currentScene;
    // public int score, foundAliens;

    public bool tutorialDone, lobbyDone, cockpitDone, dashboardDone,
        phoneCallDone, headquartersDone, labyrinthDone, engineFloorDone, 
        FuelPipesDone, engineStartDone, spaceTransitDone, gridNavigationDone, 
        medicineMeasureDone, newtonTreatedDone;

    private void Awake()
    {
        if (dataHolder == null)
        {
            DontDestroyOnLoad(gameObject);  //this object wont be destroyed between scenes
            dataHolder = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

}

[Serializable]

class PlayerData
{
    public string currentScene;
    public int score, foundAliens;

    public bool tutorialDone, lobbyDone, cockpitDone, dashboardDone,
        phoneCallDone, headquartersDone, labyrinthDone, engineFloorDone, 
        FuelPipesDone, engineStartDone, spaceTransitDone, gridNavigationDone,
        medicineMeasureDone, newtonTreatedDone;
}
