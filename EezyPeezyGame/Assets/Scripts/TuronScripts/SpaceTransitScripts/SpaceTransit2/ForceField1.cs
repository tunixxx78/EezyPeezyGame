using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ForceField1 : MonoBehaviour
{
    public static int theForceField;
    [SerializeField] GameObject fullField, mediumFiel, lowField, scorePanel, spaceShip;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private float score;

    private void Start()
    {
        theForceField = 4;
        score = 0;
    }

    private void Update()
    {
        score = score + Time.deltaTime * 100;

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
            score = Mathf.Round(score * 100.0f) * 0.01f;
            scoreText.text = score.ToString() + "KM";
            Invoke("TryAgain", 3f);
            spaceShip.SetActive(false);
            scorePanel.SetActive(true);
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
        SceneManager.LoadScene("SpaceTransit2");
    }
}
