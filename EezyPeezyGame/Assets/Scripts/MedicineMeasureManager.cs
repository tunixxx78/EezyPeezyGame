using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineMeasureManager : MonoBehaviour
{
    public Texture2D pipetteEmpty, pipetteRed, pipetteBlue, pipetteYellow;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(pipetteEmpty, hotSpot, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Red"))
            {
                Debug.Log("rayhit red");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Red");
                    Cursor.SetCursor(pipetteRed, hotSpot, CursorMode.ForceSoftware);
                }
            }

            if (hit.collider.gameObject.CompareTag("Blue"))
            {
                Debug.Log("rayhit blue");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Blue");
                    Cursor.SetCursor(pipetteBlue, hotSpot, CursorMode.ForceSoftware);
                }
            }

            if (hit.collider.gameObject.CompareTag("Yellow"))
            {
                Debug.Log("rayhit Yellow");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Yellow");
                    Cursor.SetCursor(pipetteYellow, hotSpot, CursorMode.ForceSoftware);
                }
            }

        }

    }

}
