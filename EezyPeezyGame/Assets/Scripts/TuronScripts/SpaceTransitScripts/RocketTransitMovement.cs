using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This on helds logic for moving rocket in spaceTransit scene and also handles collision logic.

public class RocketTransitMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rocket;
    [SerializeField] float speed = 1f;
    Vector3 targetPosition;
    bool isMoving = false;
    [SerializeField] private Animator rocketAnimator;
    [SerializeField] GameObject endText;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlanetIzzy"))
        {
            DataHolder.dataHolder.spaceTransitDone = true;
            Invoke("GoToIzzy", 3f);
            endText.SetActive(true);
        }
    }

    private void GoToIzzy()
    {
        if (SceneManager.GetActiveScene().name == "SpaceTransit2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene("Planet Izzy");
        }
       
    }
}
