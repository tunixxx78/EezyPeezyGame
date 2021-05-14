using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public bool newScene;
    public GameObject playerOnMap, planets;
  

    private void Start()
    {
       
        
    }
    void Update()
    {
    
        if (newScene)
        {
            playerOnMap.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            newScene = false;
        }
    }
    public void LoadScene(string SceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name!=SceneName)
        {
            newScene = true;
            SceneManager.LoadScene(SceneName);
          
        }
       
    }

}
