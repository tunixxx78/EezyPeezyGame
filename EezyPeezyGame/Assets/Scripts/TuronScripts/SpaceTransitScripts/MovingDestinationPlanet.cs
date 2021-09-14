using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This one was moving destination planet(izzy) in spaceTransit scene (at least at some point of project

public class MovingDestinationPlanet : MonoBehaviour
{

    [SerializeField] float planetSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector2.down * planetSpeed * Time.deltaTime);

        Destroy(this.gameObject, 30f);
    }
}
