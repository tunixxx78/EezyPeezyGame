using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class DataHolderSaver : MonoBehaviour
{
    [SerializeField] private TMP_Text alienAmount;

    private void Update()
    {
        int foundAliens = DataHolder.dataHolder.foundAliens;
        alienAmount.text = foundAliens.ToString(foundAliens + " collected");
    }

    public void Save()
    {
        Debug.Log("Saving data.");

        DataHolder.dataHolder.currentScene = SceneManager.GetActiveScene().name;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        data.currentScene = DataHolder.dataHolder.currentScene;
        data.foundAliens = DataHolder.dataHolder.foundAliens;

        data.tutorialDone = DataHolder.dataHolder.tutorialDone;
        data.lobbyDone = DataHolder.dataHolder.lobbyDone;
        data.cockpitDone = DataHolder.dataHolder.cockpitDone;
        data.dashboardDone = DataHolder.dataHolder.dashboardDone;
        data.phoneCallDone = DataHolder.dataHolder.phoneCallDone;
        data.headquartersDone = DataHolder.dataHolder.headquartersDone;
        data.labyrinthDone = DataHolder.dataHolder.labyrinthDone;
        data.engineFloorDone = DataHolder.dataHolder.engineFloorDone;
        data.FuelPipesDone = DataHolder.dataHolder.FuelPipesDone;
        data.engineStartDone = DataHolder.dataHolder.engineStartDone;
        data.spaceTransitDone = DataHolder.dataHolder.spaceTransitDone;
        data.gridNavigationDone = DataHolder.dataHolder.gridNavigationDone;
        data.medicineMeasureDone = DataHolder.dataHolder.medicineMeasureDone;
        data.newtonTreatedDone = DataHolder.dataHolder.newtonTreatedDone;
        bf.Serialize(file, data);
        file.Close();

    }
}
