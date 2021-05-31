using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ_DoorSlider : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse over the door collider.");
        animator.SetBool("MouseOver", true);
        if (!animator.GetBool("Open"))
        {
            Debug.Log("Opening the door, since it's not open and mouse is over.");
            animator.Play("HQDoorsOpen");
            animator.SetBool("Open", true);
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse not over the door collider.");
        animator.SetBool("MouseOver", false);

        if (animator.GetBool("Open"))
        {
            Debug.Log("Closing the door, since it's open and mouse is not over.");
            animator.Play("HQDoorsClose");
            animator.SetBool("Open", false);
        }

    }
}