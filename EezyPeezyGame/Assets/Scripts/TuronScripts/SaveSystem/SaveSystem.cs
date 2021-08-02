using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer(ScoringSystem player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dat";

        FileStream stream = new FileStream(path, FileMode.Create);

        PLRData data = new PLRData(player);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game Saved" +data);
    }

    public static PLRData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PLRData data = formatter.Deserialize(stream) as PLRData;
            stream.Close();

            Debug.Log("Game Loaded");

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}

