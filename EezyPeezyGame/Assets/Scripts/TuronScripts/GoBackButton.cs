using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButton : MonoBehaviour
{
    public void BackButton()
    {
        ScoringSystem.theScore += 100;
        SceneManager.LoadScene("SampleScene");
        Debug.Log(ScoringSystem.theScore);
    }
}
