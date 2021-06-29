using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float moveSpeed;
    public bool isMoving = false;

    Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        MoveDot();
    }

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
        if (collision.CompareTag("Goal"))
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
