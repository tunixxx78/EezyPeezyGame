using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnPoint1 : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    private void Start()
    {
        Instantiate(asteroid, transform.position, Quaternion.identity);
    }
}
