using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string toScene;
    public GameObject confirmationPanel;
    // Start is called before the first frame update
    void Start()
    {
        confirmationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("klik");
            confirmationPanel.SetActive(true);
            StartCoroutine(ConfirmationWait());
        }


    }

    IEnumerator ConfirmationWait()
    {
        yield return new WaitForSeconds(7f);
        confirmationPanel.SetActive(false);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(toScene);
    }

    public void CloseConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }
}
