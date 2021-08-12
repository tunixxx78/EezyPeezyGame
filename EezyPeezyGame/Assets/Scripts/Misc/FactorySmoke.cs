using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySmoke : MonoBehaviour
{
    public GameObject smokeParticles;
    // Start is called before the first frame update
    void Start()
    {
        smokeParticles.SetActive(false); 
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
