using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the green alien inside Rockets Lobby. If clicked, an information chat bubble appears and disappears after 7 seconds.

public class GreenAlienInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoChatBubble;
  
    void Start()
    {
        infoChatBubble.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            infoChatBubble.SetActive(true);
            Invoke("CloseChatBubble", 7f);
        }
    }

    public void CloseChatBubble()
    {
        infoChatBubble.SetActive(false);
    }
}
