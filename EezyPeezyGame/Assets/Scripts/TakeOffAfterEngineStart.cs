using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeOffAfterEngineStart : MonoBehaviour
{
    public static CursorMode lockState;
    public GameObject canvas, input, rocket, ez, pz;
    public Animator rocketAnimator;
    public AnimationClip launchClip;


    // Start is called before the first frame update
    void Start()
    {
        rocketAnimator = rocket.GetComponent<Animator>();

        if (DataHolder.dataHolder.engineStartDone && DataHolder.dataHolder.spaceTransitDone == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            canvas.SetActive(false);
            input.SetActive(false);
            ez.SetActive(false);
            pz.SetActive(false);

            rocketAnimator.Play("RocketLaunch");

            Invoke("ChangeScene", 4f);
        }
        else
        {
            canvas.SetActive(true);
            input.SetActive(true);
            ez.SetActive(true);
            pz.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void ChangeScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("SpaceTransit");
    }
}
