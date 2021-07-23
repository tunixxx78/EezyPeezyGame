using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
