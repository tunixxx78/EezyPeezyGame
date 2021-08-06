using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("klik");
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
