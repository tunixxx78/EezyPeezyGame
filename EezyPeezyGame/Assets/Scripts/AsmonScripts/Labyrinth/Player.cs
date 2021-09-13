using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float moveSpeed;
    public bool isMoving = false;
    public GameObject exitDeniedPanel, mobileArrows;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        exitDeniedPanel.SetActive(false);
    }


    void FixedUpdate()
    {
        MoveDot();
    }

    public void Update()
    {
        
        /* This isn't being used, we ran out of time to make the game work also on mobiles
        if(Input.touchSupported)
        {
            mobileArrows.SetActive(true);
        }
        else
        {
            mobileArrows.SetActive(false);
        }*/
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

    // These are not used, but could be taken further to make the game to work also on mobiles
    public void MoveUP()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    public void MoveDOWN()
    {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }

    public void MoveLEFT()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveRIGHT()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

}
