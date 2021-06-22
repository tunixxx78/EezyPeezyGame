using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    /*
     This is a simple script for interactable objects in scenes that you want to get deleted, when they are clicked once.
     Give the script to the wanted object that has an animation, set the variables in Unity for the wanted animation clip and clips name.
    */

    private Animator animator;
    public AnimationClip animClip;
    public string animName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            animator.Play(animName);
            Destroy(gameObject, animClip.length);
        }
    }
}
