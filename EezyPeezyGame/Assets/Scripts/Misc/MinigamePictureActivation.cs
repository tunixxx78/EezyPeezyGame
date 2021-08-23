using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
