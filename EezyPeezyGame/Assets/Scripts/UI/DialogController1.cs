using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController1 : MonoBehaviour
{

    public TextMeshProUGUI dialogText;
    public GameObject dialogPanel;
    public string[] dialogs;
    private int index = 0;
    public float dialogSpeed;
    private bool nextText = true;

    // Update is called once per frame
    void Update()
    {
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
        index = dialogs.Length;
        dialogPanel.SetActive(false);
    }

    void NextDialog()
    {
        if(index < dialogs.Length)
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
        foreach(char Character in dialogs[index].ToCharArray())
        {
            dialogText.text += Character;
            yield return new WaitForSeconds(dialogSpeed);
        }
        index++;
        nextText = true;
    }
}
