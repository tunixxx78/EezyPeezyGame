using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketTransitMovement1 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rocket;
    [SerializeField] float speed = 1f;
    Vector3 targetPosition;
    bool isMoving = false;
    [SerializeField] private Animator rocketAnimator;

    private void Start()
    {
    
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (isMoving)
        {
            MoveRocket();
        }
    }

    private void SetTargetPosition()
    {
        Destroy(rocketAnimator);

        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    private void MoveRocket()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            isMoving = false;
        }

    }

}
