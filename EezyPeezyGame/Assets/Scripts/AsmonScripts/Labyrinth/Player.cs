using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float moveSpeed;
    public bool isMoving = false;
    public GameObject exitDeniedPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        exitDeniedPanel.SetActive(false);
    }


    void FixedUpdate()
    {
        MoveDot();
    }

    //Player movement, making it to move only one direction at time
    void MoveDot()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isMoving == false)
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && isMoving == false)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isMoving == false)
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && isMoving == false)
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }
 
        CheckIfMoving();
    }
    
    void CheckIfMoving()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal") && DataHolder.dataHolder.labyrinthDone == false)
        {
            exitDeniedPanel.SetActive(true);
            StartCoroutine(PanelWait());
        }
    }

    IEnumerator PanelWait()
    {
        //this coroutine will shut the panel after a while if none of the buttons have been pressed
        yield return new WaitForSeconds(6f);
        exitDeniedPanel.SetActive(false);
    }

}
