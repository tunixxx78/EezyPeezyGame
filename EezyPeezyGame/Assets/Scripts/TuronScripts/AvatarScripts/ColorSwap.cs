using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This one is for changing avatar sprites.ABANDONED!

public class ColorSwap : MonoBehaviour
{

    [Header("Sprite to change")]
    [SerializeField] SpriteRenderer bodyPart;
    

    public List<Sprite> options = new List<Sprite>();
    

    private int currentOption = 0;
    

    public void NextOption()
    {
       

        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }
        
        bodyPart.sprite = options[currentOption];
        
    }

    

}
