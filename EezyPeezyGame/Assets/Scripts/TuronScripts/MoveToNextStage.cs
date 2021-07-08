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
            Invoke("GoBack", 2f);
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
        
        SceneManager.LoadScene("RocketCockpit");
    }

    
}

