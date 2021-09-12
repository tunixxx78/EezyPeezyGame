using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is for Spawning obstacle and asteroid patterns in spaceTransit scene

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPatterns;
    private float timeBtwSpawns;
    [SerializeField] private float startTimeBtwSpawns, decreaseTime, minTime = 0.65f;

    private void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, asteroidPatterns.Length);

            Instantiate(asteroidPatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;

            if(startTimeBtwSpawns > minTime)
            {
                startTimeBtwSpawns -= decreaseTime;
            }
        }

        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
