using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used in Rocket engine room for the light switch on the wall. 

public class LightSwitch : MonoBehaviour
{
    public Sprite hoverSprite, sprite;
    public GameObject lights;


    private void OnMouseOver()
    {
        if (hoverSprite != null && sprite != null)
        {
            //changing the highlight sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = hoverSprite;
        }
    }
    private void OnMouseExit()
    {
        if (hoverSprite != null && sprite != null)
        {
            //changing to the original sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    private void OnMouseDown()
    {
        // when clicking the light switch it activates and deactivates the light gameobject for the game scene
        if (Input.GetKey(KeyCode.Mouse0) && lights.activeSelf == false)
        {
            lights.SetActive(true);
        }
        else
        {
            lights.SetActive(false);
        }
    }

}
