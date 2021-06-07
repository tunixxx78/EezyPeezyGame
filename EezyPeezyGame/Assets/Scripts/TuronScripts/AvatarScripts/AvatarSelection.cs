using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarSelection : MonoBehaviour
{
    private int pointsToWin, currentPoints;
    public GameObject myObjects;
    [SerializeField] GameObject robotSelectionCanvas, RobotSelection2, robotAssembly;
    

    private void Start()
    {
        pointsToWin = myObjects.transform.childCount;
    }

    private void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            robotSelectionCanvas.SetActive(true);
            RobotSelection2.SetActive(true);
            robotAssembly.SetActive(false);
        }   
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
