using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{

    private void Start()
    {
        Invoke("RobotFlyBy", 2f);
    }

    public void ButtonPress()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/ButtonClick", GetComponent<Transform>().position);
    }

    private void RobotFlyBy()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/RobotFlyBy", GetComponent<Transform>().position);
        Invoke("Start", 6f);
    }
}
