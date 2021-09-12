using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This one is spawning actual asteroids in points that asteroidSpawner script is telling to.

public class AsteroidSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    private void Start()
    {
        Instantiate(asteroid, transform.position, Quaternion.identity);
    }
}
