using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerMedicine : MonoBehaviour
{
    [SerializeField] private GameObject emptyVial, gameFinished, gameFailed, mix, smokeParticles, particleBubbles;
    [SerializeField] private TMP_Text[] medicineText;
    [SerializeField] private Button[] medicineJar;
    [SerializeField] private Button[] whichJar;

    public AudioSource dropSound;

    private PipetteCursor pcScript;

    private Button selectedButton;

    private float blueDropCount;
    private float redDropCount;
    private float yellowDropCount;

    public float redDropsNeeded;
    public float blueDropsNeeded;
    public float yellowDropsNeeded;

    public bool redActive = false;
    public bool blueActive = false;
    public bool yellowActive = false;


    private bool activeJar;

    


    void Start()
    {
        dropSound = GetComponent<AudioSource>();
        pcScript = GetComponent<PipetteCursor>();
        JarDropCount();

        
        particleBubbles.SetActive(false);
        smokeParticles.SetActive(false);
    }



    public void JarDropCount()
    {
        blueDropCount = Random.Range(1, 7);
        medicineText[1].text = blueDropCount.ToString();
        blueDropsNeeded = blueDropCount;

        redDropCount = Random.Range(1, 7);
        medicineText[0].text = redDropCount.ToString();
        redDropsNeeded = redDropCount;

        yellowDropCount = Random.Range(1, 7);
        medicineText[2].text = yellowDropCount.ToString();
        yellowDropsNeeded = yellowDropCount;
    }



    public void Drops()
    {
        if(redActive)
        {
            dropSound.Play();
            redDropCount--;
            redActive = false;
            Debug.Log("luvut laskee");
            if (redDropCount == 0)
            {
                Debug.Log("VITTU JEE");
                redActive = false;  
            }
        }

        if (blueActive)
        {
            dropSound.Play();
            blueDropCount--;
            blueActive = false;
            Debug.Log("siniset laskee");
            if(blueDropCount == 0)
            {
                Debug.Log("KOVA!");
                blueActive = false;

            }
        }

        if (yellowActive)
        {
            dropSound.Play();
            yellowDropCount--;
            yellowActive = false;
            Debug.Log("keltaset laskee");
            if(yellowDropCount == 0)
            {
                Debug.Log("JEEEE");
                yellowActive = false;
            }
        }
    }

    public void CheckIfRightFormula()
    {
        if(redDropCount == 0 && blueDropCount == 0 && yellowDropCount == 0)
        {
            gameFinished.SetActive(true);
            particleBubbles.SetActive(true);
            DataHolder.dataHolder.medicineMeasureDone = true;
            DataHolder.dataHolder.newtonTreatedDone = true;
            FindObjectOfType<SFXManager>().PlanetExplotion();
            Invoke("GameFinished", 3f);
        }

        else
        {
            gameFailed.SetActive(true);
            StartCoroutine(ParticleEffect());
            JarDropCount();
        }
    }


    public void ActiveJarRed()
    {
        redActive = true;
        blueActive = false;
        yellowActive = false;
    }

    public void ActiveJarBlue()
    {
        redActive = false;
        blueActive = true;
        yellowActive = false;
    }

    public void ActiveJarYellow()
    {
        redActive = false;
        blueActive = false;
        yellowActive = true;
    }

    IEnumerator ParticleEffect()
    {
        smokeParticles.SetActive(true);
        yield return new WaitForSeconds(5f);
        smokeParticles.SetActive(false);
    }

    public void GameFinished()
    {
        SceneManager.LoadScene("NewtonsHouse");
    }

}
