using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerNewtonsHouse : MonoBehaviour
{
    [SerializeField] private GameObject characters1, characters2;
    [SerializeField] private GameObject ez2, pz2;
    [SerializeField] private GameObject medicineTable;


    private Animator animatorEZ, animatorPZ;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
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
