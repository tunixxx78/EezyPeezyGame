using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFormation : MonoBehaviour
{
    public GameObject notLit;
    public GameObject[] formations;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        notLit.SetActive(true);
        index = 0;
    }

    private void Update()
    {
        Debug.Log("formation index:" + index);
    }

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (index > 0 && index < 4)
            {
                formations[index - 1].SetActive(false);
            }
            else
            {
                formations[3].SetActive(false);
                index = 0;
            }
            formations[index].SetActive(true);
            index++;
        }
    }
}
