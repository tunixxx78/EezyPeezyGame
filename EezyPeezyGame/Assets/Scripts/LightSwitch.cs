using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Sprite hoverSprite, sprite;
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    private void OnMouseOver()
    {
        //changing the highlight sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = hoverSprite;
    }
    private void OnMouseExit()
    {
        //changing to the original sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0) && light.activeSelf == false)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
    }

}
