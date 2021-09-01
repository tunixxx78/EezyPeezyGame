using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This script is for the UI map, it has functions to change the scene to the wanted scene.

public class Map : MonoBehaviour
{
    public GameObject deniedText;


    private void Update()
    {
        // If player hasn't done the space transit yet, they have no access to the Planet Izzy and therefore cannot use the fast travel from the map
        if(DataHolder.dataHolder.spaceTransitDone)
        {
            deniedText.SetActive(false);
        }
        else
        {
            deniedText.SetActive(true);
        }
    }

    public void LoadIzzy()
    {
        if(DataHolder.dataHolder.spaceTransitDone)
        {
            SceneManager.LoadScene("Planet Izzy");
        }
        else
        {
            // If player hasn't done the space transit yet, they have no access to the Planet Izzy and therefore cannot use the fast travel from the map
            FindObjectOfType<SFXManager>().Denied();
        }
    }
    public void LoadRocket()
    {
        SceneManager.LoadScene("RocketLobby");
    }

    public void LoadHomePlanet()
    {
            SceneManager.LoadScene("HomePlanet");
    }
}
