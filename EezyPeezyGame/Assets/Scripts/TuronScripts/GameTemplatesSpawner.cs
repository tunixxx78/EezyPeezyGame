using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTemplatesSpawner : MonoBehaviour
{
    [SerializeField] private GameTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Start()
    {
        Invoke("Spawn", 0.1f);
       
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            rand = Random.Range(0, templates.gameSheets.Length);
            Instantiate(templates.gameSheets[rand], transform.position, Quaternion.identity);
        }
        spawned = true;
        
    }
}
