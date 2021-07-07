using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public void ButtonPress()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/ButtonClick", GetComponent<Transform>().position);
    }
}
