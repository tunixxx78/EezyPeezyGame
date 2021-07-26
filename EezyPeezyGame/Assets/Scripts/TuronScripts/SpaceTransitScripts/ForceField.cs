using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceField : MonoBehaviour
{
    public static int theForceField;
    [SerializeField] GameObject fullField, mediumFiel, lowField, tryAgainMessage, spaceShip;

    private void Start()
    {
        theForceField = 4;
    }

    private void Update()
    {
        if(theForceField > PlayerPrefs.GetInt("StrenghtOfField", 0))
        {
            PlayerPrefs.SetInt("StreghtOfField", theForceField);
        }

        if(theForceField == 4)
        {
            fullField.SetActive(true);
        }
        if(theForceField == 3)
        {
            fullField.SetActive(false);
            mediumFiel.SetActive(true);
        }
        if(theForceField == 2)
        {
            fullField.SetActive(false);
            mediumFiel.SetActive(false);
            lowField.SetActive(true);
        }
        if (theForceField == 1)
        {
            fullField.SetActive(false);
            mediumFiel.SetActive(false);
            lowField.SetActive(false);
        }
        if (theForceField == 0)
        {
            Invoke("TryAgain", 2f);
            spaceShip.SetActive(false);
            tryAgainMessage.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            theForceField -= 1;
        }
        if (collision.CompareTag("Obstacle"))
        {
            theForceField -= 1;
        }
    }

    private void TryAgain()
    {
        SceneManager.LoadScene("SpaceTransit");
    }
}
