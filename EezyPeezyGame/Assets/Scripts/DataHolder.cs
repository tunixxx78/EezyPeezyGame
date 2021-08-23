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
    public int foundAliens;

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

    public void Save()
    {
        Debug.Log("Saving data.");

        currentScene = SceneManager.GetActiveScene().name;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        data.currentScene = currentScene;
        data.foundAliens = foundAliens;

        data.tutorialDone = tutorialDone;
        data.lobbyDone = lobbyDone;
        data.cockpitDone = cockpitDone;
        data.dashboardDone = dashboardDone;
        data.phoneCallDone = phoneCallDone;
        data.headquartersDone = headquartersDone;
        data.labyrinthDone = labyrinthDone;
        data.engineFloorDone = engineFloorDone;
        data.FuelPipesDone = FuelPipesDone;
        data.engineStartDone = engineStartDone;
        data.spaceTransitDone = spaceTransitDone;
        data.gridNavigationDone = gridNavigationDone;
        data.medicineMeasureDone = medicineMeasureDone;
        data.newtonTreatedDone = newtonTreatedDone;
        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        Debug.Log("No path found.");
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            currentScene = data.currentScene;
            foundAliens = data.foundAliens;

            tutorialDone = data.tutorialDone;
            lobbyDone = data.lobbyDone;
            cockpitDone = data.cockpitDone;
            dashboardDone = data.dashboardDone;
            phoneCallDone = data.phoneCallDone;
            headquartersDone = data.headquartersDone;
            labyrinthDone = data.labyrinthDone;
            engineFloorDone = data.engineFloorDone;
            FuelPipesDone = data.FuelPipesDone;
            engineStartDone = data.engineStartDone;
            spaceTransitDone = data.spaceTransitDone;
            gridNavigationDone = data.gridNavigationDone;
            medicineMeasureDone = data.medicineMeasureDone;
            newtonTreatedDone = data.newtonTreatedDone;

            Debug.Log("Loaded gamedata.");

            SceneManager.LoadScene(currentScene);
        }

    }
}

[Serializable]

class PlayerData
{
    public string currentScene;
    public int foundAliens;

    public bool tutorialDone, lobbyDone, cockpitDone, dashboardDone,
        phoneCallDone, headquartersDone, labyrinthDone, engineFloorDone, 
        FuelPipesDone, engineStartDone, spaceTransitDone, gridNavigationDone,
        medicineMeasureDone, newtonTreatedDone;
}
