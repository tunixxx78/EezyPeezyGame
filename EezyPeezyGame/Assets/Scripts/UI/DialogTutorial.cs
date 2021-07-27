using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTutorial : MonoBehaviour
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
    public GameObject taskPanel, mapPanel, menuPanel, ez, pz;
    private Animator taskAnimator, mapAnimator, menuAnimator, ezAnimator, pzAnimator;


    private void Start()
    {
        taskAnimator = taskPanel.GetComponent<Animator>();
        mapAnimator = mapPanel.GetComponent<Animator>();
        menuAnimator = menuPanel.GetComponent<Animator>();
        ezAnimator = ez.GetComponent<Animator>();
        pzAnimator = pz.GetComponent<Animator>();

        if(DataHolder.dataHolder.tutorialDone)
        {
            dialogPanel.SetActive(false);
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

    public void SkipTutorial()
    {
        //For skip button, to skip all dialog texts and close the dialog panel
        index = dialogs.Length;
        dialogPanel.SetActive(false);
        ezAnimator.Play("EzIdle");
        pzAnimator.Play("PzIdle");
        taskAnimator.SetBool("show", false);
        mapAnimator.SetBool("show", false);
        menuAnimator.SetBool("show", false);
        DataHolder.dataHolder.tutorialDone = true;
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
            DataHolder.dataHolder.tutorialDone = true;
        }
        
    }

    IEnumerator WriteDialog()
    {
        //activates the wanted animations for the for robots and UI elements at the wanted dialog index
        if(index < 2)
        {
            ezAnimator.Play("EzWave");
            pzAnimator.Play("PzWave");
        }
        else if (index == 2)
        {
            isOpen = taskAnimator.GetBool("show");
            taskAnimator.SetBool("show", !isOpen);
        }
        else if (index == 4)
        {
            taskAnimator.SetBool("show", false);
            isOpen = mapAnimator.GetBool("show");
            mapAnimator.SetBool("show", !isOpen);
        }
        else if (index == 5)
        {
            mapAnimator.SetBool("show", false);
            isOpen = menuAnimator.GetBool("show");
            menuAnimator.SetBool("show", !isOpen);
        }
        else
        {
            menuAnimator.SetBool("show", false);
        }

        if (index >= 2)
        {
            ezAnimator.Play("EzIdle");
            pzAnimator.Play("PzIdle");
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
