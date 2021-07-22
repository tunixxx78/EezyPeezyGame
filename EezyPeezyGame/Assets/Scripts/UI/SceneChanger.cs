using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // name of the scene you want the player to go
    public string toScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        //if the mouse clicks the area (e.g. doorway), the continue panel activates and starts a couroutine 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            GoToScene();
            FMODUnity.RuntimeManager.PlayOneShot("event:/ButtonClick", GetComponent<Transform>().position);   // Turo add sound for text!
        }
    }

    public void GoToScene()
    {
        //button action for scene changing
        SceneManager.LoadScene(toScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered.");
        SceneManager.LoadScene(toScene);
    }

}
