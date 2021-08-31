using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script changes the characters accordingly in Newtons House depending on the story phase.


public class CharacterControllerNewtonsHouse : MonoBehaviour
{
    [SerializeField] private GameObject characters1, characters2;
    [SerializeField] private GameObject ez2, pz2;
    [SerializeField] private GameObject medicineTable;


    private Animator animatorEZ, animatorPZ;

    void Start()
    {
        // activates and deactivates the clickable table that takes the player to the medicine minigame
        if (DataHolder.dataHolder.newtonTreatedDone == true)
        {
            medicineTable.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            medicineTable.GetComponent<CapsuleCollider2D>().enabled = true;
        }


        animatorEZ = ez2.GetComponent<Animator>();
        animatorPZ = pz2.GetComponent<Animator>();
    }

    void Update()
    {
        // Checking the DataHolder for the status of the story and activates and deactivates the correct character holder gameobject.
        if(DataHolder.dataHolder.newtonTreatedDone == false)
        {
            characters1.SetActive(true);
            characters2.SetActive(false);
        }
        else
        {
            animatorEZ.Play("EzHighFive");
            animatorPZ.Play("PzHighFive");

            characters1.SetActive(false);
            characters2.SetActive(true);
        }
    }
}
