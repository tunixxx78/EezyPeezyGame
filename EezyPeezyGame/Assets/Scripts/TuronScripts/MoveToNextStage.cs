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
            MoveOn.SetActive(true);
            Invoke("GoBack", 2f);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }

    void GoBack()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

