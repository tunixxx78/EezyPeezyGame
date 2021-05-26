using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSystem : MonoBehaviour
{
    [SerializeField] GameObject[] avatarPrefabs;
    [SerializeField] GameObject spawnpointForAvatar;
    private void Start()
    {
        LoadAvatar();
    }

    void LoadAvatar()
    {
        int robotIndex = PlayerPrefs.GetInt("RobotIndex");
        GameObject.Instantiate(avatarPrefabs[robotIndex]);
    }
}
