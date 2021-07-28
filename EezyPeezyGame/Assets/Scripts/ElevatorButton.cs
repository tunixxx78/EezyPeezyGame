using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    // This script is connected to the elevator button. It changes the button sprite when mouse hovered and back again. When clicked, the elevator animation opens it and panel opens and starts a coroutine.
    // When clicked again, it plays the close animation.

    private Animator animator;
    public GameObject elevator;
    public GameObject elevatorPanel;
    private bool elevatorOpen;
    public Sprite hoverSprite, sprite;

    // Start is called before the first frame update
    void Start()
    {
        // taking the elevator objects animator so it can be commanded
        animator = elevator.GetComponent<Animator>();
        //setting panel and bool to false when scene starts
        elevatorOpen = false;
        elevatorPanel.SetActive(false);
    }

    private void OnMouseOver()
    {
        //changing the highlight sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = hoverSprite;
    }
    private void OnMouseDown()
    {
        // if clicked the button and elevator is not open, playing open, setting a bool and activating elevator panel -> then to coroutine "ElevatorWait"
        if (Input.GetKey(KeyCode.Mouse0) && elevatorOpen == false)
        {
            animator.Play("Open");
            elevatorPanel.SetActive(true);
            elevatorOpen = true;
            StartCoroutine(ElevatorWait());
        }
        // if clicked the button and elevator bool is true, playing the close animation and changing bool to false
        else if (Input.GetKey(KeyCode.Mouse0) && elevatorOpen == true)
        {
            animator.Play("Close");
            elevatorOpen = false;
        }
    }

    private void OnMouseExit()
    {
        //changing to the original sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    IEnumerator ElevatorWait()
    {
        //this coroutine will shut the panel after a while if none of the buttons have been pressed
        yield return new WaitForSeconds(7f);
        elevatorPanel.SetActive(false); 
    }
}
