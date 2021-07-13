using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorPanel : MonoBehaviour
{

    public GameObject elevatorPanel;

    // Start is called before the first frame update
    void Start()
    {
        elevatorPanel.SetActive(false);
    }

    private void OnMouseOver()
    {
        //if the mouse clicks the area (e.g. doorway), the continue panel activates and starts a couroutine 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            elevatorPanel.SetActive(true);
            StartCoroutine(ElevatorWait());
        }
    }

    IEnumerator ElevatorWait()
    {
        //this coroutine will shut the panel after a while if neither of the buttons have been pressed
        yield return new WaitForSeconds(7f);
        elevatorPanel.SetActive(false);
    }
}
