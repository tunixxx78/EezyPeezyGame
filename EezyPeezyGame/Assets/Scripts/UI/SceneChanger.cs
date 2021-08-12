using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            Debug.Log("klik");
            GoToScene(); 
        }
    }

    public void GoToScene()
    {
        if (SceneManager.GetActiveScene().name == "HeadQuarters" && DataHolder.dataHolder.phoneCallDone == false || SceneManager.GetActiveScene().name == "HeadQuarters" && DataHolder.dataHolder.labyrinthDone == true)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DataHolder.dataHolder.labyrinthDone == true)
        {
            Debug.Log("Trigger entered.");
            SceneManager.LoadScene(toScene);
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

}
