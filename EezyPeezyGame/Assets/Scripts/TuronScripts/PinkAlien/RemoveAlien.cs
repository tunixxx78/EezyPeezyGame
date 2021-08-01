using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAlien : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        AlienFound();
    }

    private void AlienFound()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider.CompareTag("PinkAlien"))
            {
                ScoringSystem.numberOfAliens += 1;
                animator.SetTrigger("DeathOfPiggy");
                FindObjectOfType<SFXManager>().YouFindLittlePiggy();
                Destroy(gameObject, 1f);
            }
            else
            {
                return;
            }
        }

    }

    
}
