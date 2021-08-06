using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel_Interactable : MonoBehaviour
{
    private Animator animator;
    private int animIndex;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animIndex = 0;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animIndex++;
            Debug.Log("klik");
            if(animIndex == 1)
            {
                animator.Play("1");
            }
            else if(animIndex == 2)
            {
                animator.Play("2");
            }
            else if (animIndex == 3)
            {
                animator.Play("3");
            }
            else if (animIndex == 4)
            {
                animator.Play("4");
                animIndex = 0;
            }
            else
            {
                animIndex = 0;
                animator.Play("0");
            }

            sound.Play();
        }
    }
}
