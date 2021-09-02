using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;

public class GameManagerArcade : MonoBehaviour
{
    public SpriteRenderer[] colors;
    public AudioSource[] buttonSounds;
    public Text scoreText;

    private int colorSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;
    public int inputInSequence;

    private bool gameActive = false;

    public AudioSource correct;
    public AudioSource incorrect;
    

    [SerializeField] private GameObject moveOn, failed, yourTurn, startGame;
    

    
    void Start()
    {

    }

    void Update()
    {

        if(shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;

            if (stayLitCounter < 0)
            {
                colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 0.5f);
                buttonSounds[activeSequence[positionInSequence]].Stop();

                shouldBeLit = false;

                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;
                
                positionInSequence++; 
            }
        }
        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                Cursor.lockState = CursorLockMode.None;
                shouldBeDark = false;
                gameActive = true;
                yourTurn.SetActive(true);
            }
            else
            {
                if(waitBetweenCounter < 0)
                { 
                    colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);
                    buttonSounds[activeSequence[positionInSequence]].Play();
                    
                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }

        
    }

    public void StartGame()
    {
        startGame.SetActive(false);
        activeSequence.Clear();

        positionInSequence = 0;
        inputInSequence = 0;

        colorSelect = Random.Range(0, colors.Length);

        activeSequence.Add(colorSelect);

        colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);
        buttonSounds[activeSequence[positionInSequence]].Play();

        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ColorPressed(int whichButton)
    {
        if (gameActive)
        {
            if (activeSequence[inputInSequence] == whichButton)
            {
                Debug.Log("Correct");
                
                inputInSequence++;
                

                if (inputInSequence >= activeSequence.Count)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    //Invoke("DelayFirstLight", 1f);
                    //positionInSequence = 0;
                    //inputInSequence = 0;

                    //colorSelect = Random.Range(0, colors.Length);

                    //activeSequence.Add(colorSelect);

                    //colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);
                    //buttonSounds[activeSequence[positionInSequence]].Play();

                    //stayLitCounter = stayLit;
                    //shouldBeLit = true;

                    //gameActive = false;

                    //correct.Play();
                    yourTurn.SetActive(false);
                    Invoke("DelayCorrectSound", 0.5f);
                    StartCoroutine(WaitBetweenSequences());

                }
             
            }
            else
            {
                Debug.Log("Wrong");
                incorrect.Play();
                gameActive = false;
                failed.SetActive(true);
                startGame.SetActive(true);
                yourTurn.SetActive(false);
            }
        }
    }

    public void DelayCorrectSound()
    {
        correct.Play();
    }

    public void Completed()
    {
            Cursor.lockState = CursorLockMode.None;
            DataHolder.dataHolder.engineStartDone = true;
            moveOn.SetActive(true);
            FindObjectOfType<SFXManager>().PlanetExplotion();
            Invoke("HomePlanetScene", 3f);
            
    }

    public void HomePlanetScene()
    {
        if (SceneManager.GetActiveScene().name == "SimonSays2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene("HomePlanet");
        }
        
    }

    IEnumerator WaitBetweenSequences()
    { 
        yield return new WaitForSeconds(waitBetweenLights);

        positionInSequence = 0;
        inputInSequence = 0;

        colorSelect = Random.Range(0, colors.Length);

        activeSequence.Add(colorSelect);

        colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f);
        buttonSounds[activeSequence[positionInSequence]].Play();

        stayLitCounter = stayLit;
        shouldBeLit = true;

        gameActive = false;

    }
}
