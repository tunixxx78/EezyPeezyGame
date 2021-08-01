using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDestinationPlanet : MonoBehaviour
{

    [SerializeField] float planetSpeed = 4f;

    private void Update()
    {
        transform.Translate(Vector2.down * planetSpeed * Time.deltaTime);

        Destroy(this.gameObject, 20f);
    }
}
