using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySmoke : MonoBehaviour
{
    public GameObject smokeParticles, signBoard;
    // Start is called before the first frame update
    void Start()
    {
        smokeParticles.SetActive(false);

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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            StartCoroutine(ReleaseSmoke());

        }
    }

    IEnumerator ReleaseSmoke()
    {
        smokeParticles.SetActive(true);
        yield return new WaitForSeconds(9f);
        smokeParticles.SetActive(false);
    }
}
