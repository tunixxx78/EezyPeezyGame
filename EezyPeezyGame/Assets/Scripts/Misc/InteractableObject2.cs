using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject2 : MonoBehaviour
{
    /*
     This is a simple script for interactable objects in scenes that are animated when they are clicked.
     Give the script to the wanted object that has an animation, set the variables in Unity for the wanted animation clip and clips name and a sound if wanted.
    */

    private Animator animator;
    public AnimationClip animClip;
    public string animName;
    public AudioSource sound;

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
            if(animator != null && animClip != null && animName != null)
            {
                animator.Play(animName);
            }


            
            if(sound != null)
            {
                sound.Play();
            }
            else
            {
                return;
            }
            
        }
    }
}
