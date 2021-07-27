using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
