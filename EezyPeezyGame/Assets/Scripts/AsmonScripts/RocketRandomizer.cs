using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RocketRandomizer : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject rocketPrefab;

    private int randPosition;

    public float spawnRate = 2f;
    public float nextSpawn = 0f;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randPosition = Random.Range(0, spawnPoint.Length);
            

            Instantiate(rocketPrefab, spawnPoint[randPosition].position, Quaternion.identity);    
        }
    }


}
