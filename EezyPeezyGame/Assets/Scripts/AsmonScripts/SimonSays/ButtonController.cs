using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSprite;

    public int thisButtonNumber;

    private GameManager theGM;

    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);

    }

    private void OnMouseUp()
    {
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        theGM.ColorPressed(thisButtonNumber);
    }
}
