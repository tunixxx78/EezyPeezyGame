using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used in Home Planet scene for the interactable windows that change the colors formations, creating shapes.

public class LightFormation : MonoBehaviour
{
    public GameObject notLit;
    public GameObject[] formations;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        notLit.SetActive(true);
        index = 0;
    }


    // When clicking it goes trough each of the formations in the gameobject array by increasing the index
    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (index > 0 && index < 4)
            {
                formations[index - 1].SetActive(false);
            }
            else
            {
                formations[3].SetActive(false);
                index = 0;
            }
            formations[index].SetActive(true);
            index++;
        }
    }
}
