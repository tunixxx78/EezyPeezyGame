using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAlienInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoChatBubble;
    // Start is called before the first frame update
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
