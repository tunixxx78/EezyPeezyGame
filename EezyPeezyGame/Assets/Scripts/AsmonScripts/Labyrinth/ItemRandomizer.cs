using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomizer : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] itemPrefab;
    //public GameObject[] collectedItem;
    //public Transform[] collectedSpawnPoint;

    private int randPosition;

    public bool spawnAllowed;

    public int i = 0;
    public int amountThings;


    void Start()
    {
        Spawn();
        //randPosition = Random.Range(0, spawnPoint.Length);
        
        //for(int i = 0; i < itemPrefab.Length; i++)
        //{
        //    randPosition = Random.Range(0, spawnPoint.Length);
        //    itemPrefab[i] = Instantiate(itemPrefab[i], spawnPoint[randPosition].position, Quaternion.identity);
            
        //}
    }

    public void Spawn()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(spawnPoint);
        for (i = 0; i < amountThings; i++)
        {
            if (freeSpawnPoints.Count <= 0)
                return;
            int index = Random.Range(0, freeSpawnPoints.Count);
            Transform pos = freeSpawnPoints[index];
            freeSpawnPoints.RemoveAt(index);
            
            Instantiate(itemPrefab[i], pos.position, pos.rotation);
        }
    }

}
