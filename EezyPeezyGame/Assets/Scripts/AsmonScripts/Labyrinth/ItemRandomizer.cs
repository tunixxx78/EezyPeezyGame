using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomizer : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] itemPrefab;

    private int randPosition;
    
    


    void Start()
    {
        //randPosition = Random.Range(0, spawnPoint.Length);
        
        for(int i = 0; i < itemPrefab.Length; i++)
        {
            randPosition = Random.Range(0, spawnPoint.Length);
            itemPrefab[i] = Instantiate(itemPrefab[i], spawnPoint[randPosition].position, Quaternion.identity);
        }   
    }

    
}
