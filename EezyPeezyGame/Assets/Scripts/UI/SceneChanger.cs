using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // name of the scene you want the player to go
    public string toScene;
    //continue panel to change scene or cancel
    public GameObject confirmationPanel;
    // Start is called before the first frame update
    void Start()
    {
        //at start the panel needs to be deactive
        confirmationPanel.SetActive(false);
    }

    private void OnMouseOver()
    {
        //if the mouse clicks the area (e.g. doorway), the continue panel activates and starts a couroutine 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            confirmationPanel.SetActive(true);
            StartCoroutine(ConfirmationWait());
        }
    }

    IEnumerator ConfirmationWait()
    {
        //this coroutine will shut the panel after a while if neither of the buttons have been pressed
        yield return new WaitForSeconds(7f);
        confirmationPanel.SetActive(false);
    }

    public void GoToScene()
    {
        //button action for scene changing
        SceneManager.LoadScene(toScene);
    }

    public void CloseConfirmationPanel()
    {
        //button for cancelling and deactivating the continue panel
        confirmationPanel.SetActive(false);
    }
}
