using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuelPipesDenied : MonoBehaviour
{
    public GameObject cabinet;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "RocketEngineFloor" && DataHolder.dataHolder.labyrinthDone == false || SceneManager.GetActiveScene().name == "HeadQuarters" && DataHolder.dataHolder.FuelPipesDone == true)
        {
            cabinet.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            cabinet.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
