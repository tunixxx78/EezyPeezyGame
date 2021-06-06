using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienCountManager : MonoBehaviour
{
    [SerializeField] Text alienCount;

    private void Start()
    {
        NumberOfAliens();
    }

    private void NumberOfAliens()
    {
        int numberOfAliens = PlayerPrefs.GetInt("NumberOfAliens");
        alienCount.text = numberOfAliens.ToString();
    }
}
