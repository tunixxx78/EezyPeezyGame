using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameArcadeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameConsoles;

    private void Start()
    {
        foreach(GameObject obj in gameConsoles)
        {
            obj.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (DataHolder.dataHolder.dashboardDone)
        {
            gameConsoles[0].SetActive(true);
        }

        if (DataHolder.dataHolder.labyrinthDone)
        {
            gameConsoles[1].SetActive(true);
        }

        if (DataHolder.dataHolder.FuelPipesDone)
        {
            gameConsoles[2].SetActive(true);
        }

        if (DataHolder.dataHolder.engineStartDone)
        {
            gameConsoles[3].SetActive(true);
        }

        if (DataHolder.dataHolder.spaceTransitDone)
        {
            gameConsoles[4].SetActive(true);
        }

        if (DataHolder.dataHolder.gridNavigationDone)
        {
            gameConsoles[5].SetActive(true);
        }

        if (DataHolder.dataHolder.medicineMeasureDone)
        {
            gameConsoles[6].SetActive(true);
        }
    }
}
