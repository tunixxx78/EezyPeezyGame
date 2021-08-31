using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script makes it possible to go to the Newtons house scene by clicking on it in Planet Izzy scene after the Map navigation game is done.


public class NewtonsHouseActivation : MonoBehaviour
{
    [SerializeField] private GameObject newtonsHouseActive;

    void Update()
    {
        if(DataHolder.dataHolder.gridNavigationDone)
        {
            newtonsHouseActive.SetActive(true);
        }
        else
        {
            newtonsHouseActive.SetActive(false);

        }
    }
}
