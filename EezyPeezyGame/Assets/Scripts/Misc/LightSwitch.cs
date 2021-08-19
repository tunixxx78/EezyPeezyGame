using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightSwitch : MonoBehaviour
{
    public Sprite hoverSprite, sprite;
    public GameObject lights;
    // Start is called before the first frame update
    void Start()
    {
        lights.SetActive(false);
        
    }

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
