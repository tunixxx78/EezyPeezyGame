using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

//This one contains information of games sfx

public class SFXManager : MonoBehaviour
{

    public AudioSource button, doorOpening, typing, fireworks, littlePiggy, cursor, denied, dataSaved;

    public static SFXManager sfxInstance;

    public GameObject avatar;

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

    public void CreateAndSaveAvatar()
    {
        //PrefabUtility.SaveAsPrefabAsset(avatar, "assets/Prefabs/TestPrefabs/avatar.prefab");
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

    public void CursorChange()
    {
        cursor.Play();
    }

    public void Denied()
    {
        denied.Play();
    }

    public void DataSaved()
    {
        dataSaved.Play();
    }
}
