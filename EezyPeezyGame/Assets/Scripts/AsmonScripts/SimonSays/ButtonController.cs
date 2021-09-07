using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSprite;

    public int thisButtonNumber;

    private GameManager theGM;

    private AudioSource theSound;

    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManager>();
        theSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(theGM.inputInSequence == 6)
        {
            Destroy(theSound);
            return;
        }
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
    }
}
