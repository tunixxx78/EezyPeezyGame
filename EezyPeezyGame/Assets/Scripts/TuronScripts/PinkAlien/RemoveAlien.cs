using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAlien : MonoBehaviour
{

    void Update()
    {
        AlienFound();
    }

    private void AlienFound()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            /*RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {

                }
            }*/
      
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("PinkAlien"))
            {
                ScoringSystem.numberOfAliens += 1;
                Destroy(gameObject, 0.5f);
            }
            else
            {
                return;
            }
        }

    }
}
