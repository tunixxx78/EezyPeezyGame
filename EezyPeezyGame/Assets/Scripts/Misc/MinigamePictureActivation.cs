using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used in Rocket Arcade to change the picture on the TV screen depending on which game console the player hovers on.
// This is attached to the consoles.

public class MinigamePictureActivation : MonoBehaviour
{
    [SerializeField] private GameObject picture;


    private void Start()
    {
        picture.SetActive(false);
    }
    private void OnMouseEnter()
    {
        picture.SetActive(true);
    }

    private void OnMouseExit()
    {
        picture.SetActive(false);
    }
}
