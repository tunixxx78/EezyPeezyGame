using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarSystem : MonoBehaviour
{
    [SerializeField] GameObject[] avatarPrefabs;
    
    private void Start()
    {
        LoadAvatar();
    }

    void LoadAvatar()
    {
        int robotIndex = PlayerPrefs.GetInt("RobotIndex");
        GameObject.Instantiate(avatarPrefabs[robotIndex], transform.position, Quaternion.identity);
    }
    public void GoGoGo()
    {
        //SceneManager.LoadScene("SampleScene");
    }
}
