using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerArcade : MonoBehaviour
{
    private SpriteRenderer theSprite;

    public int thisButtonNumber;

    private GameManagerArcade theGM;

    private AudioSource theSound;

    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManagerArcade>();
        theSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
        theSound.Play();
    }

    private void OnMouseUp()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        theGM.ColorPressed(thisButtonNumber);
        //theSound.Stop();
    }
}
