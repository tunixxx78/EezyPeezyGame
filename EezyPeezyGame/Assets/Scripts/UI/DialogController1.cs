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
    public string[] dialogs;
    private int index = 0;
    public float dialogSpeed;
    private bool nextText = true;

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
        index = dialogs.Length;
        dialogPanel.SetActive(false);
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
        }
    }

    IEnumerator WriteDialog()
    {
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
