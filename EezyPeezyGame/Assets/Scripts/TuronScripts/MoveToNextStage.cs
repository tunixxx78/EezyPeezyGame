using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextStage : MonoBehaviour
{
    private int pointsToWin, currentPoints;
    public GameObject myObjects;
    [SerializeField] private GameObject MoveOn;

    private void Start()
    {
        pointsToWin = myObjects.transform.childCount;
    }

    private void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            DataHolder.dataHolder.dashboardDone = true;
            Invoke("GoBack", 2f);
            FindObjectOfType<SFXManager>().PlanetExplotion();
            MoveOn.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }

    void GoBack()
    {
        ScoringSystem.theScore += 10;
        Debug.Log(ScoringSystem.theScore);
        if(SceneManager.GetActiveScene().name == "DashboardAssembly2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene("RocketCockpit");
        }
       
    }

    
}

