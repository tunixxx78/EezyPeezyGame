using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is controlling the sliding UI panels

public class SliderManager : MonoBehaviour
{
    public GameObject panel;

   
    public void ShowHidePanel()
    {
        if(panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }
}
