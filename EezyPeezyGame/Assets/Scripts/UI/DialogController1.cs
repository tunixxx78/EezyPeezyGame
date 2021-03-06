using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController1 : MonoBehaviour
{
    /*
     This script is for basic dialogs in scenes that need a dialog. Add this to an empty object "DialogController" and set the variables. Dont forget to use the canvas prefab to get the variable objects needed.
     */

    public TextMeshProUGUI dialogText;
    public GameObject dialogPanel;
    public string[] dialog1;
    public string[] dialog2;
    private string[] currentDialog;
    public string dialogPart;
    private int index = 0;
    public float dialogSpeed;
    private bool nextText = true;
   


    private void Start()
    {
        // Oh lord. This is a mess, but it checks for each scene their correct dialog (1 or 2) or deactivates the panel if the dialog is done.
        // This one has most likely some pot holes and it's logic might be faulty when not progressing in the game as intended.
        if (dialogPart == "HomePlanet" && DataHolder.dataHolder.dashboardDone)
        {
            dialogPanel.SetActive(false);
        }
        else if(dialogPart == "Lobby" && DataHolder.dataHolder.lobbyDone || dialogPart == "Lobby" && DataHolder.dataHolder.dashboardDone)
        {
            dialogPanel.SetActive(false);
        }
        else if(dialogPart == "Cockpit" && DataHolder.dataHolder.dashboardDone && DataHolder.dataHolder.FuelPipesDone == false || dialogPart == "Cockpit" && DataHolder.dataHolder.engineStartDone)
        {
            dialogPanel.SetActive(false);
        }
        else if (dialogPart == "Headquarters" && DataHolder.dataHolder.dashboardDone == false || dialogPart == "Headquarters" && DataHolder.dataHolder.FuelPipesDone)
        {
            dialogPanel.SetActive(false);
        }
        else if (dialogPart == "Planet Izzy" && DataHolder.dataHolder.gridNavigationDone == true)
        {
            dialogPanel.SetActive(false);
        }
        else if(dialogPart == "Headquarters" && DataHolder.dataHolder.labyrinthDone == true)
        {
            currentDialog = dialog2;
        }
        else if (dialogPart == "EngineFloor" && DataHolder.dataHolder.labyrinthDone == false || dialogPart == "EngineFloor" && DataHolder.dataHolder.engineStartDone)
        {
            dialogPanel.SetActive(false);
        }
        else if (dialogPart == "EngineFloor" && DataHolder.dataHolder.FuelPipesDone == true)
        {
            currentDialog = dialog2;
        }
        else if (dialogPart == "Cockpit" && DataHolder.dataHolder.FuelPipesDone == true)
        {
            currentDialog = dialog2;
        }
        else if (dialogPart == "NewtonsHouse" && DataHolder.dataHolder.newtonTreatedDone == true)
        {
            
            currentDialog = dialog2;
        }
        else
        {
            currentDialog = dialog1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //preventing the use of input until the bool is true again after the coroutine
        if (nextText == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                nextText = false;
                NextDialog();
            }
        }
    }

    public void UIInputForDialog()
    {
        //This is same as pressing Enter but for UI element
        if (nextText == true)
        {
            nextText = false;
            NextDialog();
        }
    }

    public void SkipDialog()
    {
        //For skip button, to skip all dialog texts and close the dialog panel
        index = currentDialog.Length;
        dialogPanel.SetActive(false);
        CheckDialog();
    }

    void NextDialog()
    {
        //for next button, sets new index and calls the coroutine to star writing the next dialog line, if no index is bigger than the list of dialogs, the panel deactivates
        if (index < currentDialog.Length)
        {
            dialogText.text = "";
            StartCoroutine(WriteDialog());
            
        }
        else
        {
            dialogPanel.SetActive(false);
            CheckDialog();
        }
    }

    IEnumerator WriteDialog()
    {
        //this is the part of the coroutine that "animates" the text
        foreach (char Character in currentDialog[index].ToCharArray())
        {
            dialogText.text += Character;
            
            yield return new WaitForSeconds(dialogSpeed);
            
        }
        //growing index for new dialog text and changing the bool nextText so that enter or next button can be pressed again
        index++;
        nextText = true; 
    }

    public void CheckDialog()
    {
        // updating the correct story bool after the dialog
        if(dialogPart == "Lobby")
        {
            DataHolder.dataHolder.lobbyDone = true;
        }
        if (dialogPart == "Cockpit")
        {
            DataHolder.dataHolder.cockpitDone = true;
        }
        if (dialogPart == "Dashboard")
        {
            DataHolder.dataHolder.dashboardDone = true;
        }
        if (dialogPart == "PhoneCall")
        {
            DataHolder.dataHolder.phoneCallDone = true;
        }
        if (dialogPart == "Headquarters")
        {
            DataHolder.dataHolder.headquartersDone = true;
        }
        if (dialogPart == "Labyrinth")
        {
            DataHolder.dataHolder.labyrinthDone = true;
        }
        if (dialogPart == "EngineFloor")
        {
            DataHolder.dataHolder.engineFloorDone = true;
        }
        else
        {
            return;
        }
        dialogPanel.SetActive(false);
    }

    
}
