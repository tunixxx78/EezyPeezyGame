using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D dot;
    [SerializeField] private float speed = 500f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();

        }
        if (isMoving)
        {
            Move();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dots")
        {
            ScoringSystem.theDots += 1;
            DestroyObject(other.gameObject);
        }    
    }
    
}
