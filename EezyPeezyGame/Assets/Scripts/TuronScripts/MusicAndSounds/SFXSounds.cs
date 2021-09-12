using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Abandoned scripts for some sfx.

public class SFXSounds : MonoBehaviour
{
    public void PressThisButton()
    {
        FindObjectOfType<SFXManager>().ButtonPress();
    }

    public void TypingSounds()
    {
        FindObjectOfType<SFXManager>().TypingSound();
    }

    public void GoToSpace()
    {
        SceneManager.LoadScene("SpaceTransit");
    }
}
