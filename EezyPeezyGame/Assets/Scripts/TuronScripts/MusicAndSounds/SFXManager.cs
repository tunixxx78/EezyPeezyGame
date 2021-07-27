using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    
    public AudioSource button, doorOpening, typing, fireworks, littlePiggy;

    public static SFXManager sfxInstance;

    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }

    public void ButtonPress()
    {
        button.Play();
    }

    public void TypingSound()
    {
        typing.Play();
    }

    public void OpeningDoorSound()
    {
        doorOpening.Play();
    }

    public void PlanetExplotion()
    {
        fireworks.Play();
    }
    public void YouFindLittlePiggy()
    {
        littlePiggy.Play();
    }
}
