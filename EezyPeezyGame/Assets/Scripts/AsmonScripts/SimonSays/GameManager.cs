using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer[] colors;
    public AudioSource[] buttonSounds;

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
        //AI's Input and making the light stay up for x amount of time on each button press
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
            //Player's turn
            if (positionInSequence >= activeSequence.Count)
            {
                Cursor.lockState = CursorLockMode.None;
                shouldBeDark = false;
                gameActive = true;
                yourTurn.SetActive(true);
                
            }
            else
            {   //AI's turn and making the game wait x amount of time between button press
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

    //Checking if player input is correct or wrong
    public void ColorPressed(int whichButton)
    {
        if (gameActive)
        {
            if (activeSequence[inputInSequence] == whichButton)
            {  
                inputInSequence++;
                

                if (inputInSequence >= activeSequence.Count)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    
                    yourTurn.SetActive(false);
                    Invoke("DelayCorrectSound", 0.5f);
                    StartCoroutine(WaitBetweenSequences());


                    if (inputInSequence == 6)
                    {
                        
                        gameActive = false;
                        Completed();
                    }
                }
             
            }
            else
            {
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

    // When the game is completed
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
    //Makes the game wait second between player's and AI's turn
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
