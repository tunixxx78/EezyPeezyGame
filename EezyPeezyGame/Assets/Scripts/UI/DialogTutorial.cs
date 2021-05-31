using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTutorial : MonoBehaviour
{

    public TextMeshProUGUI dialogText;
    public GameObject dialogPanel;
    public string[] dialogs;
    private int index = 0;
    public float dialogSpeed;
    private bool nextText = true;
    public bool isOpen;
    public GameObject taskPanel, mapPanel, menuPanel;
    private Animator taskAnimator, mapAnimator, menuAnimator;

    // Update is called once per frame
    void Update()
    {
        taskAnimator = taskPanel.GetComponent<Animator>();
        mapAnimator = mapPanel.GetComponent<Animator>();
        menuAnimator = menuPanel.GetComponent<Animator>();

        if (nextText == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                nextText = false;
                NextDialog();
            }
        } 
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
        if (index == 2)
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



        foreach (char Character in dialogs[index].ToCharArray())
        {
            dialogText.text += Character;
            yield return new WaitForSeconds(dialogSpeed);
        }
        index++;
        nextText = true;
    }
}
