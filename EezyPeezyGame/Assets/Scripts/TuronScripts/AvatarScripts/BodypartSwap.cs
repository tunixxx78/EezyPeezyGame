using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This on is for selecting avatar parts that player wants.

public class BodypartSwap : MonoBehaviour
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

    public void PreviousOption()
    {
        currentOption--;

        if (currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }
        bodyPart.sprite = options[currentOption];
    }
}
