using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject deniedText;


    private void Update()
    {
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
