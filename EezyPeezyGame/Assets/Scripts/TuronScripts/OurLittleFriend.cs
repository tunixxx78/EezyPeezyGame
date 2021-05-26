using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OurLittleFriend : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpaceShip"))
        {
            Destroy(gameObject);
            ScoringSystem.theScore += 500;
            SceneManager.LoadScene("SampleScene");

        }
    }
}
