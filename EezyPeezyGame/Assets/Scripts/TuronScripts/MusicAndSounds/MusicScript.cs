using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This one creates music instrance for games background music.

public class MusicScript : MonoBehaviour
{
    public static MusicScript musicInstance;

    private void Awake()
    {
        if (musicInstance != null && musicInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        musicInstance = this;
        DontDestroyOnLoad(this);
    }
}
