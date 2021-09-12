using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This one is moving asteroids and helds a logic for what collisions do.

public class MovingAsteroids : MonoBehaviour
{
    [SerializeField] float asteroidSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector2.down * asteroidSpeed * Time.deltaTime);

        Destroy(this.gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Rocket"))
        {
            FindObjectOfType<SFXManager>().PlanetExplotion();
            Destroy(this.gameObject);
        }
    }

    
}
