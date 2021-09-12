using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This on is spawning pink aliens in random positions in screen.

public class PinkAlienSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    private void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;


        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
   
}
