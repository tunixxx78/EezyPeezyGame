using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script is in Rocket Cockpit, attached to an empty game object that controls the phone dialog part of the story.
// It has very similar functionalities as the DialogController1.


public class PhoneDialogController : MonoBehaviour
{

    public TextMeshProUGUI dialogText;
    public GameObject dialogPanel;
    //an array of all the dialog sentences you want to go through
    public string[] dialogs;
    //index to keep track of arrays index in for each loop
    private int index = 0;
    //how fast does the text animate to the panel
    public float dialogSpeed;
    //this prevents the user to press next until the text is fully animated -> otherwise it will cause a bug and gibberish 
    private bool nextText = true;
    //bool checks if the panel is open
    public bool isOpen;
    public GameObject chatBubble, electra, newton, doctorBag, ez, pz, phoneConsole, callIcon, callWaves;
    private Animator phoneConsoleAnimator, ezAnimator, pzAnimator;
    public GameObject dashboardGame, simonSaysGame, pilot, liftOffButton;
    public AudioSource sneeze;


    private void Start()
    {
        // At the start of the scene we check which part of the story the player is in from the DataHolder
        if(DataHolder.dataHolder.dashboardDone && DataHolder.dataHolder.phoneCallDone == false)
        {
            dialogPanel.SetActive(true);
            phoneConsoleAnimator = phoneConsole.GetComponent<Animator>();
            ezAnimator = ez.GetComponent<Animator>();
            pzAnimator = pz.GetComponent<Animator>();
            chatBubble.SetActive(false);
            electra.SetActive(false);
            newton.SetActive(false);
            doctorBag.SetActive(false);
            doctorBag.SetActive(false);
            callIcon.SetActive(false);
            callWaves.SetActive(false);
        }
        else
        {
            return;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        // In case the player didn't finish the Space Transit minigame and wants to do the lift off again, there will be a button activated on the dashboard
        if(DataHolder.dataHolder.engineStartDone && DataHolder.dataHolder.spaceTransitDone == false)
        {
            liftOffButton.SetActive(true);
        }
        else
        {
            // When the Space Transit is finished, it cannot be accessed anymore by this activation button, but from the arcade.
            liftOffButton.SetActive(false);
        }

        //preventing the use of input until the bool is true again after the coroutine
        if (nextText == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                nextText = false;
                NextDialog();
            }
        }

        // Doing a check of the status of the storyline in order to activate a correct game and also the Pilot character
        if (DataHolder.dataHolder.labyrinthDone && DataHolder.dataHolder.FuelPipesDone && DataHolder.dataHolder.engineStartDone == false)
        {
            simonSaysGame.SetActive(true);
            pilot.SetActive(true);
            dashboardGame.SetActive(false);
        }
        else if (DataHolder.dataHolder.dashboardDone == false)
        {
            dashboardGame.SetActive(true);
            simonSaysGame.SetActive(false);
        }
        else if (DataHolder.dataHolder.engineStartDone)
        {
            pilot.SetActive(true);
            simonSaysGame.SetActive(false);
            dashboardGame.SetActive(false);
        }
        else
        {
            simonSaysGame.SetActive(false);
            dashboardGame.SetActive(false);
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

    public void SkipTutorial()
    {
        //For skip button, to skip all dialog texts and close the dialog panel
        index = dialogs.Length;
        dialogPanel.SetActive(false);
        ezAnimator.Play("EzIdle");
        pzAnimator.Play("PzIdle");
        phoneConsoleAnimator.Play("Idle");
        index = dialogs.Length + 1;
        DataHolder.dataHolder.phoneCallDone = true;
        chatBubble.SetActive(false);
        electra.SetActive(false);
        newton.SetActive(false);
        doctorBag.SetActive(false);
        doctorBag.SetActive(false);
        callIcon.SetActive(false);
        callWaves.SetActive(false);
    }

    void NextDialog()
    {
        //for next button, sets new index and calls the coroutine to star writing the next dialog line, if no index is bigger than the list of dialogs, the panel deactivates
        if (index < dialogs.Length)
        {
            dialogText.text = "";
            StartCoroutine(WriteDialog());
        }
        else
        {
            // if index is bigger than the lenght of the dialog array, the following will be deactivated and DataHolder updated
            dialogPanel.SetActive(false);
            callIcon.SetActive(false);
            callWaves.SetActive(false);
            phoneConsoleAnimator.Play("Idle");
            chatBubble.SetActive(false);
            DataHolder.dataHolder.phoneCallDone = true;
        }
        
    }

    IEnumerator WriteDialog()
    {
        // This checks the index of each dialog line and does the wanted activations and deactivations accoriding to the story
        // It's a coroutine for the sake of animating the text.
        if (index == 2)
        {
            chatBubble.SetActive(true);
            electra.SetActive(true);
            ezAnimator.Play("Wave");
            pzAnimator.Play("Wave");
        }
        else if (index == 3)
        {
            electra.SetActive(false);
            newton.SetActive(true);
            sneeze.Play();
        }
        else if  (index > 3)
        {
            newton.SetActive(false);
            doctorBag.SetActive(true);
            
        }

        if (index >= 2)
        {
            callIcon.SetActive(false);
            callWaves.SetActive(false);
            phoneConsoleAnimator.Play("Idle");
        }
        else
        {
            callIcon.SetActive(true);
            callWaves.SetActive(true);
            phoneConsoleAnimator.Play("IncomingCall");
        }

        //this is the part of the coroutine that "animates" the text
        foreach (char Character in dialogs[index].ToCharArray())
        {
            dialogText.text += Character;
            yield return new WaitForSeconds(dialogSpeed);
        }
        //growing index for new dialog text and changing the bool nextText so that enter or next button can be pressed again
        index++;
        nextText = true;
    }
}
