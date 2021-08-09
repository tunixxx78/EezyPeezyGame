using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject[] collectedItem;
    public int items;

    private void Start()
    {
        items = 0;
    }

    private void Update()
    {
        if(items == 5)
        {
            DataHolder.dataHolder.labyrinthDone = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Mask"))
        {
            collectedItem[0].SetActive(true);
            Destroy(collision.gameObject);
            items++;
        }
        if (collision.CompareTag("Needle"))
        {
            collectedItem[1].SetActive(true);
            Destroy(collision.gameObject);
            items++;
        }
        if (collision.CompareTag("Pill"))
        {
            collectedItem[2].SetActive(true);
            Destroy(collision.gameObject);
            items++;
        }
        if (collision.CompareTag("Stetoscope"))
        {
            collectedItem[3].SetActive(true);
            Destroy(collision.gameObject);
            items++;
        }
        if (collision.CompareTag("Thermometer"))
        {
            collectedItem[4].SetActive(true);
            Destroy(collision.gameObject);
            items++;
        }
    }
}
