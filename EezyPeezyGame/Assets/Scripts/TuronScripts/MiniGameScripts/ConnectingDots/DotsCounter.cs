using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotsCounter : MonoBehaviour
{
    public GameObject dotHolder;
    public GameObject[] dots;

    int totalDots = 0;
    [SerializeField] int collectedDots = 0;
    [SerializeField] GameTemplates templates;
    private GameObject spawnedObj;

    int gameSheetRandomization;
    bool spawned = false;

    private void Start()
    {
        ScoringSystem.theDots = 0;
        PlayerPrefs.SetInt("DotsCollected", 0);
        SpawnDots();

        dotHolder = templates.gameSheets[gameSheetRandomization];

        totalDots = dotHolder.transform.childCount;
        dots = new GameObject[totalDots];

        for (int i = 0; i < dots.Length; i++)
        {
            dots[i] = dotHolder.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        collectedDots = ScoringSystem.theDots;

        if (collectedDots == totalDots)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void SpawnDots()
    {
        if (spawned == false)
        {
            gameSheetRandomization = Random.Range(0, templates.gameSheets.Length);
            spawnedObj = Instantiate(templates.gameSheets[gameSheetRandomization], transform.position, Quaternion.identity);
        }
        spawned = true;
    }

}
