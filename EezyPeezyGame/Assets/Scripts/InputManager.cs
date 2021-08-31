using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* This script is in each game scene in an empty gameobject and it's function "BackToPreviousScene" are attached to the door UI button.
 * The script works also with ESC button. It's job is to return the player to the scene they should if they want to go back to where they came from.
 */

public class InputManager : MonoBehaviour
{
    // this one is needed to check on the active scene
    Scene scene;
    
    void Start()
    {
        // scene manager gets you the active scene
        scene = SceneManager.GetActiveScene();
    }


    void Update()
    {
       // ESC input also calls the function to go back
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // calling the function
            BackToPreviousScene();
        }

    }

    // This function does checking and loading to get to the next scene. For those scenes from which you can't go back by -1 build index, there are multiple checks.
    public void BackToPreviousScene()
    {
        if (scene.name == "RocketCockpit" || scene.name == "RocketArcade" || scene.name == "RocketEngineFloor" || scene.name == "Planet Izzy")
        {
            SceneManager.LoadScene("RocketLobby");
        }
        else if (scene.name == "HeadQuarters")
        {
            SceneManager.LoadScene("HomePlanet");
        }
        else if (scene.name == "FuelPipes")
        {
            SceneManager.LoadScene("RocketEngineFloor");
        }
        else if (scene.name == "SimonSays")
        {
            SceneManager.LoadScene("RocketCockpit");
        }
        else if (scene.name == "SpaceTransit")
        {
            SceneManager.LoadScene("RocketCockpit");
        }
        else if (scene.name == "NewtonsHouse")
        {
            SceneManager.LoadScene("Planet Izzy");
        }
        else if(scene.name == "Labyrinth2" || scene.name == "FuelPipes2" || scene.name == "SpaceTransit2" || scene.name == "DashboardAssembly2" || scene.name == "SimonSays2" || scene.name == "MapNavigation2" || scene.name == "MedicineMeasuring2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene(scene.buildIndex - 1);
        }
    }
}
