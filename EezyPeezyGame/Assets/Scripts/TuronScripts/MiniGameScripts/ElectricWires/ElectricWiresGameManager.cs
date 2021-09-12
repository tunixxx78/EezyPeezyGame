using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Game logic for when you win game or lose

public class ElectricWiresGameManager : MonoBehaviour
{
    public GameObject wireHolder, gameFinishedBanner;
    public GameObject[] wires;

    int totalWires = 0;
    [SerializeField] int correctWires = 0;
    [SerializeField] ElectricTemplates templates;

    int gameSheetRandomization;
    bool spawned = false;

    private void Start()
    {
        gameFinishedBanner.SetActive(false);
        Spawn();

        wireHolder = templates.gameSheets[gameSheetRandomization];

        totalWires = wireHolder.transform.childCount;
        wires = new GameObject[totalWires];

        for (int i = 0; i < wires.Length; i++)
        {
            wires[i] = wireHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctWires += 1;
        if(correctWires == totalWires)
        {
            DataHolder.dataHolder.FuelPipesDone = true;
            gameFinishedBanner.SetActive(true);
            FindObjectOfType<SFXManager>().PlanetExplotion();
            Invoke("GameFinished", 3f);
        }
    }

    public void WrongMove()
    {
        correctWires -= 1;
    }

    public void Spawn()
    {
        if (spawned == false)
        {
            gameSheetRandomization = Random.Range(0, templates.gameSheets.Length);
            Instantiate(templates.gameSheets[gameSheetRandomization], transform.position, Quaternion.identity);
        }
        spawned = true;
    }

    public void GameFinished()
    {
        if (SceneManager.GetActiveScene().name == "FuelPipes2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene("RocketEngineFloor");
        }
       
    }
}
