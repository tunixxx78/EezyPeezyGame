using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}

