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
        if (Input.GetKeyDown(KeyCode.M))
        {
            //map.SetActive(!map.activeInHierarchy);
        }
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (scene.name == "RocketCockpit")
            {
                SceneManager.LoadScene("RocketLobby");
            }
            else if (scene.name == "HeadQuarters")
            {
                SceneManager.LoadScene("HomePlanet");
            }
            else
            {
                SceneManager.LoadScene(scene.buildIndex - 1);
            }
        }

    }
}
