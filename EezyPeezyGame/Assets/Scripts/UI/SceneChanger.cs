using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script can be added to any gameobject that you want to have a trigger that moves the player to a new scene

public class SceneChanger : MonoBehaviour
{
    // name of the scene you want the player to go
    public string toScene;
    public AudioSource sceneDenied;
    
    private void OnMouseOver()
    {
        //if the mouse clicks the area (e.g. doorway), the continue panel activates and starts a couroutine 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            GoToScene(); 
        }
    }

    // Scene changing function
    public void GoToScene()
    {
        // this if check is used in Headquarters to deny the player from entering the labyrinth if it's either done already or the player hasn't done the phone call scene yet
        if (SceneManager.GetActiveScene().name == "HeadQuarters" && DataHolder.dataHolder.dashboardDone == false || SceneManager.GetActiveScene().name == "HeadQuarters" && DataHolder.dataHolder.labyrinthDone == true)
        {
            if(sceneDenied != null)
            {
                sceneDenied.Play();
            }
            else
            {
                return;
            }
            
        }
        else
        {
            //button action for scene changing
            SceneManager.LoadScene(toScene);
        }
        
    }

    // This is used for the labyrinth exit door, in which the player moves into a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DataHolder.dataHolder.labyrinthDone == true)
        {
            Debug.Log("Trigger entered.");
            if (SceneManager.GetActiveScene().name == "Labyrinth2")
            {
                SceneManager.LoadScene("RocketArcade");
            }
            else
            {
                SceneManager.LoadScene(toScene); 
            }
            
        }
        else
        {
            if (sceneDenied != null)
            {
                sceneDenied.Play();
            }
            else
            {
                return;
            }
        }
        
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
