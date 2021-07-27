using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    /*
     This script is for door animating when mouse hovers over it.
     You need opening, openidle and closing animations.
     Remember to set the animation names correctly as "Open" and "Close", also the bools need to be named the same as in this script "MouseOver" and "Open"
     */

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //setting the bool to false when scene activated
        animator.SetBool("Open", false);
    }

    private void OnMouseOver()
    {
        //When mouse hovers over a collider of animated door, setting bools and animating
        //If mouse stays, the animation goes to openIdle
        Debug.Log("Mouse over the door collider.");
        animator.SetBool("MouseOver", true);
        if (!animator.GetBool("Open"))
        {
            Debug.Log("Opening the door, since it's not open and mouse is over.");
            animator.Play("Open");
            animator.SetBool("Open", true);
            
        }
    }

    private void OnMouseExit()
    {
        //When mouse doesnt hover over the collider, sets bools and acitvates the closing animation
        Debug.Log("Mouse not over the door collider.");
        animator.SetBool("MouseOver", false);

        if (animator.GetBool("Open"))
        {
            Debug.Log("Closing the door, since it's open and mouse is not over.");
            animator.Play("Close");
            animator.SetBool("Open", false);
            
        }
    }
}
