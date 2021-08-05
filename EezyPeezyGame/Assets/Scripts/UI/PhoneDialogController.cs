using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject dashboardGame, simonSaysGame, pilot;


    private void Start()
    {
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

        //preventing the use of input until the bool is true again after the coroutine
        if (nextText == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                nextText = false;
                NextDialog();
            }
        }

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
        //activates the wanted animations for the for robots and UI elements at the wanted dialog index
        
        
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
