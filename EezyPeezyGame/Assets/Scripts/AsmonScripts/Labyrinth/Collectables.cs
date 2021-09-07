using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    public GameObject[] collectedItem;
    public int items;
    public AudioSource collectSound, sceneDenied;
    public bool arcadeDone;
    public GameObject exitDeniedPanel;

    private void Start()
    {
        items = 0;
        arcadeDone = false;
    }

    private void Update()
    {
        if(items == 5 && DataHolder.dataHolder.labyrinthDone == false)
        {
            DataHolder.dataHolder.labyrinthDone = true;
            FindObjectOfType<SFXManager>().PlanetExplotion();
        }
        else if (items == 5 && DataHolder.dataHolder.labyrinthDone == true)
        {
            FindObjectOfType<SFXManager>().PlanetExplotion();
            arcadeDone = true;
        }
        
    }
    //Checking which Item is collected and making them appear on right side of the screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Mask"))
        {
            collectedItem[0].SetActive(true);
            Destroy(collision.gameObject);
            items++;
            collectSound.Play();
        }
        if (collision.CompareTag("Needle"))
        {
            collectedItem[1].SetActive(true);
            Destroy(collision.gameObject);
            items++;
            collectSound.Play();
        }
        if (collision.CompareTag("Pill"))
        {
            collectedItem[2].SetActive(true);
            Destroy(collision.gameObject);
            items++;
            collectSound.Play();
        }
        if (collision.CompareTag("Stetoscope"))
        {
            collectedItem[3].SetActive(true);
            Destroy(collision.gameObject);
            items++;
            collectSound.Play();
        }
        if (collision.CompareTag("Thermometer"))
        {
            collectedItem[4].SetActive(true);
            Destroy(collision.gameObject);
            items++;
            collectSound.Play();
        }

        if (collision.gameObject.CompareTag("Goal") && arcadeDone == false)
        {
            exitDeniedPanel.SetActive(true);
            sceneDenied.Play();
            StartCoroutine(PanelWait());
        }

        if(collision.gameObject.CompareTag("Goal") && arcadeDone == true)
        {
            SceneManager.LoadScene("RocketArcade");
        }
    }

    IEnumerator PanelWait()
    {
        //this coroutine will shut the panel after a while if none of the buttons have been pressed
        yield return new WaitForSeconds(6f);
        exitDeniedPanel.SetActive(false);
    }
}
