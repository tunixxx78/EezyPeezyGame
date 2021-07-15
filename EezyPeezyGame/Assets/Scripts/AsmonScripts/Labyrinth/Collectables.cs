using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject[] collectedItem;

    public bool collected;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Mask"))
        {
            collectedItem[0].SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Needle"))
        {
            collectedItem[1].SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Pill"))
        {
            collectedItem[2].SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Stetoscope"))
        {
            collectedItem[3].SetActive(true);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Thermometer"))
        {
            collectedItem[4].SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
