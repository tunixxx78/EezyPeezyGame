using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskPanelManager : MonoBehaviour
{
    public TextMeshProUGUI task1, task2, task3, task4, task5, task6, task7;
    public Image taskImage1, taskImage2, taskImage3, taskImage4, taskImage5,
        taskImage6, taskImage7;
    public GameObject toSimonSays, dashboardAssemble;

    // Update is called once per frame
    void Update()
    {

        if (DataHolder.dataHolder.tutorialDone == true)
        {
            task1.text = "Fix the dashboard inside the rocket";
        }
        else
        {
            task1.text = "???";
        }

        if (DataHolder.dataHolder.tutorialDone == true && DataHolder.dataHolder.dashboardDone == true)
        {
            task2.text = "Help Dr. Fizz to find his equipment in Headquarters";
            taskImage1.color = Color.green;
        }
        else
        {
            task2.text = "???";
        }

        if (DataHolder.dataHolder.dashboardDone == true && DataHolder.dataHolder.labyrinthDone == true)
        {
            task3.text = "Check engine fuel inside the rocket";
            taskImage2.color = Color.green;
        }
        else
        {
            task3.text = "???";
        }

        if (DataHolder.dataHolder.dashboardDone == true && DataHolder.dataHolder.labyrinthDone == true && DataHolder.dataHolder.FuelPipesDone == true)
        {
            task4.text = "Start the rocket's engine with the dashboard in the rocket";
            taskImage3.color = Color.green;
            toSimonSays.SetActive(true);
            dashboardAssemble.SetActive(false);
        }
        else
        {
            task4.text = "???";
        }

        if (DataHolder.dataHolder.engineStartDone == true)
        {
            task5.text = "Manoeuvre through asteroid storms in space with the rocket";
            taskImage4.color = Color.green;
        }
        else
        {
            task5.text = "???";
        }

        if (DataHolder.dataHolder.spaceTransitDone == true)
        {
            task6.text = "Find the way to Newton's house with the map on the infoboard";
            taskImage5.color = Color.green;
        }
        else
        {
            task6.text = "???";
        }

        if (DataHolder.dataHolder.gridNavigationDone == true)
        {
            task7.text = "Assist Dr. Fizz to measure the correct amount of medicine for Newton";
            taskImage6.color = Color.green;
        }
        else
        {
            task7.text = "???";
        }

        if (DataHolder.dataHolder.medicineMeasureDone == true)
        {
            taskImage6.color = Color.green;
        }
       
    }
}
