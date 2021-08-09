using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeOffAfterEngineStart : MonoBehaviour
{
    public static CursorMode lockState;
    public GameObject canvas, input, rocket;
    public Animator rocketAnimator;
    public AnimationClip launchClip;


    // Start is called before the first frame update
    void Start()
    {
        rocketAnimator = rocket.GetComponent<Animator>();

        if (DataHolder.dataHolder.engineStartDone)
        {
            Cursor.lockState = CursorLockMode.Locked;
            canvas.SetActive(false);
            input.SetActive(false);

            rocketAnimator.Play("RocketLaunch");

            Invoke("ChangeScene", 4f);
        }

    }
    public void ChangeScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("SpaceTransit");
    }
}
