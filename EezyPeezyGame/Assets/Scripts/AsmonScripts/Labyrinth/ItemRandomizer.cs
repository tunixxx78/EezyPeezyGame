using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomizer : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] itemPrefab;
    public GameObject[] collectedItem;
    public Transform[] collectedSpawnPoint;

    private int randPosition;
    private int collectedPosition;

    public bool spawnAllowed;
    
    


    void Start()
    {
        //randPosition = Random.Range(0, spawnPoint.Length);
        
        for(int i = 0; i < itemPrefab.Length; i++)
        {
            randPosition = Random.Range(0, spawnPoint.Length);
            itemPrefab[i] = Instantiate(itemPrefab[i], spawnPoint[randPosition].position, Quaternion.identity);
            spawnAllowed = true;
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectedPosition = Random.Range(0, collectedSpawnPoint.Length);

        if (collision.CompareTag("Mask"))
        {
            collectedItem[0] = Instantiate(collectedItem[0], collectedSpawnPoint[0].position, Quaternion.identity);    
        }
    }

}
