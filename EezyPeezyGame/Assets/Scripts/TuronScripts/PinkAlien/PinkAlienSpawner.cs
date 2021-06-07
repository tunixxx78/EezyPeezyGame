using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkAlienSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;

    private void Start()
    {
        SpawnObjects();
    }

    private void Update()
    {
        //AlienFound();
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
    /*private void AlienFound()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {

                }
            }
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            if (hit2D.collider.CompareTag("PinkAlien"))
            {
                print(hit2D.collider.gameObject);
                Destroy(gameObject, 0.5f);
            }
        }
        
    }*/
}
