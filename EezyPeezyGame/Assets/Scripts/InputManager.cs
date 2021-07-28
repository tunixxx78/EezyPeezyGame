using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    //public GameObject map;
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackToPreviousScene();
        }

    }

    public void BackToPreviousScene()
    {
        if (scene.name == "RocketCockpit")
        {
            SceneManager.LoadScene("RocketLobby");
        }
        else if (scene.name == "HeadQuarters")
        {
            SceneManager.LoadScene("HomePlanet");
        }
        else if (scene.name == "RocketArcade")
        {
            SceneManager.LoadScene("RocketLobby");
        }
        else if (scene.name == "RocketEngineFloor")
        {
            SceneManager.LoadScene("RocketLobby");
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
            SceneManager.LoadScene("HomePlanet");
        }
        else
        {
            SceneManager.LoadScene(scene.buildIndex - 1);
        }
    }
}
