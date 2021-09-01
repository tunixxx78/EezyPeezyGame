using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script disables the Fuel Pipes minigame if labyrinth isn't done or the fuel pipes minigame is finished

public class FuelPipesDenied : MonoBehaviour
{
    public GameObject cabinet;
    

    // Start is called before the first frame update
    void Start()
    {
        if (DataHolder.dataHolder.labyrinthDone == false || DataHolder.dataHolder.FuelPipesDone == true)
        {
            cabinet.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            cabinet.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
