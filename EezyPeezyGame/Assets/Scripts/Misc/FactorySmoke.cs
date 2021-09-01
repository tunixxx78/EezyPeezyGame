using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the interactable factory exhaustion chimney. It's also used for deactivating the mapnavigation minigame once it has been completed.

public class FactorySmoke : MonoBehaviour
{
    public GameObject smokeParticles, signBoard;
    // Start is called before the first frame update
    void Start()
    {
        smokeParticles.SetActive(false);

        // checking if the game is done or not and deactivating/activating it's box collider that determines if it can be used for scene change
        if (DataHolder.dataHolder.gridNavigationDone == true)
        {
            signBoard.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            signBoard.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnMouseOver()
    {
        // interacting with the chimney
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(ReleaseSmoke());

        }
    }

    // coroutine that activates the particle effect and then deactivates it
    IEnumerator ReleaseSmoke()
    {
        smokeParticles.SetActive(true);
        yield return new WaitForSeconds(9f);
        smokeParticles.SetActive(false);
    }
}
