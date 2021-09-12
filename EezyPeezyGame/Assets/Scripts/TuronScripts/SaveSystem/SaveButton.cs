using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of abandonet saveSystem.

public class SaveButton : MonoBehaviour
{
    public void SaveButtonForAllScenes()
    {
        FindObjectOfType<ScoringSystem>().SavePlayer();
    }

    public void LoadButtonForAllScenes()
    {
        FindObjectOfType<ScoringSystem>().LoadPlayer();
    }
}
