using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for the Headquarter robot arm animations. It has two different kinds of animated moves, therefore it has it's own script.

public class RobotArmInteractables : MonoBehaviour
{
    private Animator animator;
    private int animIndex;

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
            
            if (animIndex == 0)
            {
                animator.Play("1");
                animIndex++;
            }
            else
            {
                animator.Play("2");
                animIndex = 0;
            }
            
        }
    }
}
