using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is for Arcade version of the labyrinth. It's attached to the Level changing button.

public class LabyrinthLevel : MonoBehaviour
{
    public GameObject[] labTemplates;
    private int index;

    private void Start()
    {
        index = 0;
        labTemplates[index].SetActive(true);
    }

    public void ChangeTemplate()
    {
        Destroy(GameObject.FindGameObjectWithTag("Mask"));
        Destroy(GameObject.FindGameObjectWithTag("Needle"));
        Destroy(GameObject.FindGameObjectWithTag("Pill"));
        Destroy(GameObject.FindGameObjectWithTag("Stetoscope"));
        Destroy(GameObject.FindGameObjectWithTag("Thermometer"));

        if (index < labTemplates.Length - 1)
        {
            labTemplates[index].SetActive(false);
            index++;
            labTemplates[index].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Labyrinth2");
        }
    }
}
